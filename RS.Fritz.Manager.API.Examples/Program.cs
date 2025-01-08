#pragma warning disable CA1506 // Avoid excessive class coupling
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RS.Fritz.Manager.API;

// Register the Fritz services in the dependency container using AddFritzApi()
using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => services.AddFritzApi())
    .Build();

using IServiceScope serviceScope = host.Services.CreateScope();

// Search for routers and take the first one
IDeviceSearchService deviceSearchService = serviceScope.ServiceProvider.GetRequiredService<IDeviceSearchService>();
GroupedInternetGatewayDevice groupedInternetGatewayDevice = (await deviceSearchService.GetInternetGatewayDevicesAsync()).First();

// Select the router's internal AVM (FritzBox) device, as opposed to a generic UPnP device
InternetGatewayDevice device = groupedInternetGatewayDevice.Devices.First(q => q.IsAvm);

// Show the device model from UPnP data
Console.WriteLine($"Device model: {device.UPnPDescription?.Device?.ModelDescription}");

// Initialize the device for TR-064, retrieves the security port and the users
await device.InitializeAsync();

// Provide the password for the last logged on user
string lastUsedUserName = device.Users!.OrderByDescending(q => q.LastUser).First().Name;
Console.WriteLine($"Enter password for {lastUsedUserName}:");
device.NetworkCredential = new(lastUsedUserName, Console.ReadLine());

// TR-064 example; show the device uptime from the TR-064 DeviceInfo service
DeviceInfoGetInfoResponse deviceInfo = await device.DeviceInfoGetInfoAsync();
Console.WriteLine($"Device uptime: {TimeSpan.FromSeconds(deviceInfo.Uptime)}");

// Special services

// Retrieving the device users manually
IUsersService usersService = serviceScope.ServiceProvider.GetRequiredService<IUsersService>();
IEnumerable<User> users = await usersService.GetUsersAsync(device);
users.ToList().ForEach(q => Console.WriteLine($"User: {q.Name}"));

// Retrieving a list of device hosts in the network
IDeviceHostsService deviceHostsService = serviceScope.ServiceProvider.GetRequiredService<IDeviceHostsService>();
DeviceHostInfo deviceHostInfo = await deviceHostsService.GetDeviceHostsAsync(device);
deviceHostInfo.DeviceHosts.ToList().ForEach(q => Console.WriteLine($"Device host: {q.HostName}"));

// Retrieving a list of mesh hosts in the network
IDeviceMeshService deviceMeshService = serviceScope.ServiceProvider.GetRequiredService<IDeviceMeshService>();
DeviceMeshInfo deviceMeshInfo = await deviceMeshService.GetDeviceMeshAsync(device);
deviceMeshInfo.DeviceMesh.Nodes.ToList().ForEach(q => Console.WriteLine($"Mesh host: {q.DeviceName}"));

// Retrieving a list of WLAN devices in the network
IWlanDeviceService wlanDeviceService = serviceScope.ServiceProvider.GetRequiredService<IWlanDeviceService>();
WlanDeviceInfo wlanDeviceInfo = await wlanDeviceService.GetWlanDevicesAsync(device);
wlanDeviceInfo.WlanDeviceList.Items.ToList().ForEach(q => Console.WriteLine($"WLAN device: {q.AssociatedDeviceIpAddress}"));

// Retrieve a new session for use in the WebUI
IWebUiService webUiService = serviceScope.ServiceProvider.GetRequiredService<IWebUiService>();
WebUiSessionInfo webUiSessionInfo = await webUiService.LogonAsync(device);
Console.WriteLine($"Session: {webUiSessionInfo.Sid}");

// Capture live network traffic from router to file
ICaptureControlService captureControlService = serviceScope.ServiceProvider.GetRequiredService<ICaptureControlService>();
IEnumerable<CaptureInterfaceGroup> interfaceGroups = await captureControlService.GetInterfacesAsync(device);
CaptureInterface captureInterface = interfaceGroups.First().CaptureInterfaces.First();
var fileInfo = new FileInfo(FormattableString.Invariant($@"c:\temp\{captureInterface.Name}_{DateTime.Now.ToString("s").Replace(":", string.Empty)}.eth"));

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
Task.Run(() => StopCaptureAsync(device, captureInterface, TimeSpan.FromSeconds(10), captureControlService));
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

await captureControlService.StartCaptureAsync(device, fileInfo, captureInterface);
Console.WriteLine($"Network trace written to file: {fileInfo}");

return;

static async Task StopCaptureAsync(InternetGatewayDevice device, CaptureInterface captureInterface, TimeSpan timeSpan, ICaptureControlService captureControlService)
{
    await Task.Delay(timeSpan);
    await captureControlService.StopCaptureAsync(device, captureInterface);
}
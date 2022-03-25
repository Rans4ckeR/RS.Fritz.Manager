# RS.Fritz.Manager
Allows FritzBox device detection, monitoring, configuring and network traffic capturing. The TR-064 implementation is using pure WCF Soap calls.

Available as a standalone Windows application ([UI](#rsfritzmanagerui)) and as a NuGet package ([API](#rsfritzmanagerapi)).

For a list of implemented services check the [Service implementation status](#tr-064-service-implementation-status)


## RS.Fritz.Manager.UI
A Windows .NET WPF application for x64 and ARM64.

* [Releases](https://github.com/Rans4ckeR/RS.Fritz.Manager/releases)

![Screenshot 2022-03-19 210434](https://user-images.githubusercontent.com/25006126/159136777-0ab554b3-e196-45e0-ac98-b19e03fcbf87.png)

### Usage Instructions
1. Click Discover Internet Gateway Devices
2. Select a detected device
3. Select a detected user
4. Enter the selected user's password
5. Click Login
6. Use the Device Information tab to see device details

## RS.Fritz.Manager.API
A NuGet package to manage FritzBox devices using pure WCF calls.

* [NuGet](https://www.nuget.org/packages/RS.Fritz.Manager.API)
* [GitHub](https://github.com/Rans4ckeR/RS.Fritz.Manager/packages/1302526)

### Usage Examples

```C#
using System.Net;
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
InternetGatewayDevice device = (await deviceSearchService.GetDevicesAsync()).First();

// Show the device model from UPnP data
Console.WriteLine($"Device model: {device.UPnPDescription.Device.ModelDescription}");

// Initialize the device for TR-064, retrieves the security port and the users
await device.InitializeAsync();

// Provide the password for the last logged on user
string lastUsedUserName = device.Users.Single(q => q.LastUser).Name;
Console.WriteLine($"Enter password for {lastUsedUserName}:");
device.NetworkCredential = new NetworkCredential(lastUsedUserName, Console.ReadLine());

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

// Retrieve a new session for use in the WebUI
IWebUiService webUiService = serviceScope.ServiceProvider.GetRequiredService<IWebUiService>();
WebUiSessionInfo webUiSessionInfo = await webUiService.LogonAsync(device);
Console.WriteLine($"Session: {webUiSessionInfo.Sid}");

// Capture live network traffic from router to file
ICaptureControlService captureControlService = serviceScope.ServiceProvider.GetRequiredService<ICaptureControlService>();
Task.Run(() => StopCaptureAfter1SecondsAsync(device, captureControlService));
FileInfo fileInfo = await captureControlService.GetStartCaptureResponseAsync(device, "c:\\temp", "capturefile");
Console.WriteLine($"Network trace written to file: {fileInfo}");

await host.RunAsync();

static async Task StopCaptureAfter1SecondsAsync(InternetGatewayDevice device, ICaptureControlService captureControlService)
{
    await Task.Delay(1000);
    await captureControlService.GetStopCaptureResponseAsync(device);
}
```

## TR-064 Service implementation status

### WAN
* 🔶 urn:dslforum-org:service:WANIPConnection:1
  * ✅ GetInfo
  * ✅ GetConnectionTypeInfo
  * ❌ SetConnectionType
  * ✅ GetStatusInfo
  * ✅ GetNATRSIPStatus
  * ❌ SetConnectionTrigger
  * ❌ ForceTermination
  * ❌ RequestConnection
  * ✅ X_GetDNSServers
  * ✅ GetPortMappingNumberOfEntries
  * ✅ GetGenericPortMappingEntry
  * ❌ GetSpecificPortMappingEntry
  * ❌ AddPortMapping
  * ❌ DeletePortMapping
  * ✅ GetExternalIPAddress
  * ❌ SetRouteProtocolRx
  * ❌ SetIdleDisconnectTime
* 🔶 urn:dslforum-org:service:WANPPPConnection:1
  * ✅ GetInfo
  * ✅ GetConnectionTypeInfo
  * ❌ SetConnectionType
  * ✅ GetStatusInfo
  * ✅ GetLinkLayerMaxBitRates
  * ✅ GetUserName
  * ❌ SetUserName
  * ❌ SetPassword
  * ✅ GetNATRSIPStatus
  * ❌ SetConnectionTrigger
  * ❌ ForceTermination
  * ❌ RequestConnection
  * ✅ X_GetDNSServers
  * ✅ GetPortMappingNumberOfEntries
  * ✅ GetGenericPortMappingEntry
  * ❌ GetSpecificPortMappingEntry
  * ❌ AddPortMapping
  * ❌ DeletePortMapping
  * ✅ GetExternalIPAddress
  * ❌ SetRouteProtocolRx
  * ❌ SetIdleDisconnectTime
  * ✅ X_AVM_DE_GetAutoDisconnectTimeSpan
  * ❌ X_AVM_DE_SetAutoDisconnectTimeSpan
* ✅ urn:dslforum-org:service:WANCommonInterfaceConfig:1
  * ✅ GetCommonLinkProperties
  * ✅ GetTotalBytesSent
  * ✅ GetTotalBytesReceived
  * ✅ GetTotalPacketsSent
  * ✅ GetTotalPacketsReceived
  * ✅ X_AVM-DE_SetWANAccessType
  * ✅ X_AVM-DE_GetOnlineMonitor
* ✅ urn:dslforum-org:service:WANEthernetLinkConfig:1
  * ✅ GetEthernetLinkStatus
* ✅ urn:dslforum-org:service:WANDSLInterfaceConfig:1
  * ✅ GetInfo
  * ✅ GetStatisticsTotal
  * ✅ X_AVM-DE_GetDSLDiagnoseInfo
  * ✅ X_AVM-DE_GetDSLInfo
* 🔶 urn:dslforum-org:service:WANDSLLinkConfig:1
  * ✅ GetInfo
  * ❌ SetEnable
  * ❌ SetDSLLinkType
  * ✅ GetDSLLinkInfo
  * ❌ SetDestinationAddress
  * ✅ GetDestinationAddress
  * ❌ SetATMEncapsulation
  * ✅ GetATMEncapsulation
  * ✅ GetAutoConfig
  * ✅ GetStatistics
* 🔶 urn:dslforum-org:service:X_AVM-DE_Speedtest:1
  * ✅ GetInfo
  * ❌ SetConfig
* ❌ urn:dslforum-org:service:X_AVM-DE_RemoteAccess:1
* ❌ urn:dslforum-org:service:X_AVM-DE_MyFritz:1
* ❌ urn:dslforum-org:service:X_AVM-DE_HostFilter:1
* 🔶 urn:dslforum-org:service:Layer3Forwarding:1
  * ❌ SetDefaultConnectionService
  * ✅ GetDefaultConnectionService
  * ✅ GetForwardNumberOfEntries
  * ❌ AddForwardingEntry
  * ❌ DeleteForwardingEntry
  * ❌ GetSpecificForwardingEntry
  * ✅ GetGenericForwardingEntry
  * ❌ SetForwardingEntryEnable

### Telephony
* ❌ urn:dslforum-org:service:X_AVM-DE_OnTel:1
* ❌ urn:dslforum-org:service:X_AVM-DE_TAM:1
* ❌ urn:dslforum-org:service:X_VoIP:1

### Home network
* 🔶 urn:dslforum-org:service:Hosts:1
  * ✅ GetHostNumberOfEntries
  * ❌ GetSpecificHostEntry
  * ✅ GetGenericHostEntry
  * ✅ X_AVM-DE_GetChangeCounter
  * ❌ X_AVM-DE_GetAutoWakeOnLANByMACAddress
  * ❌ X_AVM-DE_SetAutoWakeOnLANByMACAddress
  * ❌ X_AVM-DE_SetHostNameByMACAddress
  * ❌ X_AVM-DE_WakeOnLANByMACAddress
  * ❌ X_AVM-DE_GetSpecificHostEntryByIp
  * ❌ X_AVM-DE_HostsCheckUpdate
  * ❌ X_AVM-DE_HostDoUpdate
  * ✅ X_AVM-DE_GetHostListPath
  * ✅ X_AVM-DE_GetMeshListPath
* ❌ urn:dslforum-org:service:WLANConfiguration:1
* ❌ urn:dslforum-org:service:LANHostConfigManagement:1
* 🔶 urn:dslforum-org:service:LANEthernetInterfaceConfig:1
  * ❌ SetEnable
  * ✅ GetInfo
  * ❌ GetStatistics
* ❌ urn:dslforum-org:service:X_AVM-DE_Dect:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Homeauto:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Homeplug:1

### Storage/NAS
* ❌ urn:dslforum-org:service:X_AVM-DE_Storage:1
* ❌ urn:dslforum-org:service:X_AVM-DE_UPnP:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Filelinks:1

### System
* ✅ urn:dslforum-org:service:DeviceInfo:1
  * ✅ GetInfo
  * ✅ SetProvisioningCode
  * ✅ GetDeviceLog
  * ✅ GetSecurityPort
* ❌ urn:dslforum-org:service:DeviceConfig:1
* ✅ urn:dslforum-org:service:LANConfigSecurity:1
  * ✅ GetInfo
  * ✅ X_AVM-DE_GetAnonymousLogin
  * ✅ X_AVM-DE_GetCurrentUser
  * ✅ SetConfigPassword
  * ✅ X_AVM-DE_GetUserList
* ❌ urn:dslforum-org:service:X_AVM-DE_AppSetup:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Auth:1
* ❌ urn:dslforum-org:service:Time:1
* ❌ urn:dslforum-org:service:UserInterface:1

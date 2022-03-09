namespace RS.Fritz.Manager.UI;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class HostsViewModel : FritzServiceViewModel
{
    private readonly IDeviceHostsService deviceHostsService;

    private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
    private DeviceHostInfo? deviceHostInfo;
    private HostsGetGenericHostEntryResponse? hostsGetGenericHostEntryResponse;

    public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IDeviceHostsService deviceHostsService)
        : base(deviceLoginInfo, logger)
    {
        this.deviceHostsService = deviceHostsService;
    }

    public HostsGetHostNumberOfEntriesResponse? HostsGetHostNumberOfEntriesResponse
    {
        get => hostsGetHostNumberOfEntriesResponse; set { _ = SetProperty(ref hostsGetHostNumberOfEntriesResponse, value); }
    }

    public DeviceHostInfo? DeviceHostInfo
    {
        get => deviceHostInfo; set { _ = SetProperty(ref deviceHostInfo, value); }
    }

    public HostsGetGenericHostEntryResponse? HostsGetGenericHostEntryResponse
    {
        get => hostsGetGenericHostEntryResponse; set { _ = SetProperty(ref hostsGetGenericHostEntryResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync()
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetHostsGetHostListPathAsync(),
                GetHostsGetHostNumberOfEntriesAsync(),
                GetHostsGetGenericHostEntryAsync()
            });
    }

    private async Task GetHostsGetHostNumberOfEntriesAsync()
    {
        HostsGetHostNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.GetHostsGetHostNumberOfEntriesAsync(d));
    }

    private async Task GetHostsGetGenericHostEntryAsync()
    {
        const ushort getHostsGetGenericHostEntryIndex = 0;

        HostsGetGenericHostEntryResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.GetHostsGetGenericHostEntryAsync(d, getHostsGetGenericHostEntryIndex));
    }

    private async Task GetHostsGetHostListPathAsync()
    {
        HostsGetHostListPathResponse newHostsGetHostListPathResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.GetHostsGetHostListPathAsync(d));
        string hostListPath = newHostsGetHostListPathResponse.HostListPath;
        Uri hostListPathUri = new Uri(FormattableString.Invariant($"https://{DeviceLoginInfo.InternetGatewayDevice.InternetGatewayDevice!.PreferredLocation.Host}:{DeviceLoginInfo.InternetGatewayDevice.InternetGatewayDevice.SecurityPort}{hostListPath}"));
        IEnumerable<DeviceHost> deviceHosts = await deviceHostsService.GetDeviceHostsAsync(hostListPathUri);

        DeviceHostInfo = new DeviceHostInfo(hostListPath, hostListPathUri, new ObservableCollection<DeviceHost>(deviceHosts));
    }
}
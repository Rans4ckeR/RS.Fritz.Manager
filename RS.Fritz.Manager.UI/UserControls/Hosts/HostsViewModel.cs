namespace RS.Fritz.Manager.UI;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class HostsViewModel : FritzServiceViewModel
{
    private readonly IDeviceHostsService deviceHostsService;

    private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
    private DeviceHostInfo? deviceHostInfo;

    public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IDeviceHostsService deviceHostsService, HostsGetGenericHostEntryViewModel hostsGetGenericHostEntryViewModel)
        : base(deviceLoginInfo, logger)
    {
        HostsGetGenericHostEntryViewModel = hostsGetGenericHostEntryViewModel;
        this.deviceHostsService = deviceHostsService;
    }

    public HostsGetGenericHostEntryViewModel HostsGetGenericHostEntryViewModel { get; }

    public HostsGetHostNumberOfEntriesResponse? HostsGetHostNumberOfEntriesResponse
    {
        get => hostsGetHostNumberOfEntriesResponse;
        private set
        {
            if (SetProperty(ref hostsGetHostNumberOfEntriesResponse, value))
                HostsGetGenericHostEntryViewModel.HostNumberOfEntries = HostsGetHostNumberOfEntriesResponse?.HostNumberOfEntries;
        }
    }

    public DeviceHostInfo? DeviceHostInfo
    {
        get => deviceHostInfo;
        private set { _ = SetProperty(ref deviceHostInfo, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetHostsGetHostListPathAsync(cancellationToken),
                GetHostsGetHostNumberOfEntriesAsync()
            });
    }

    private async Task GetHostsGetHostNumberOfEntriesAsync()
    {
        HostsGetHostNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.HostsGetHostNumberOfEntriesAsync();
    }

    private async Task GetHostsGetHostListPathAsync(CancellationToken cancellationToken)
    {
        HostsGetHostListPathResponse newHostsGetHostListPathResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.HostsGetHostListPathAsync();
        string hostListPath = newHostsGetHostListPathResponse.HostListPath;
        var hostListPathUri = new Uri(FormattableString.Invariant($"https://{DeviceLoginInfo.InternetGatewayDevice.ApiDevice.PreferredLocation.Host}:{DeviceLoginInfo.InternetGatewayDevice.ApiDevice.SecurityPort}{hostListPath}"));
        IEnumerable<DeviceHost> deviceHosts = await deviceHostsService.GetDeviceHostsAsync(hostListPathUri, cancellationToken);

        DeviceHostInfo = new DeviceHostInfo(hostListPath, hostListPathUri, new ObservableCollection<DeviceHost>(deviceHosts));
    }
}
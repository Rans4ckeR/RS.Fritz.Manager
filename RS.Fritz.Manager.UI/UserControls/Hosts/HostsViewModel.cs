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
    private readonly IDeviceMeshService deviceMeshService;

    private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
    private HostsGetChangeCounterResponse? hostsGetChangeCounterResponse;
    private DeviceHostInfo? deviceHostInfo;

    public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IDeviceHostsService deviceHostsService, IDeviceMeshService deviceMeshService, HostsGetGenericHostEntryViewModel hostsGetGenericHostEntryViewModel)
        : base(deviceLoginInfo, logger)
    {
        HostsGetGenericHostEntryViewModel = hostsGetGenericHostEntryViewModel;
        this.deviceHostsService = deviceHostsService;
        this.deviceMeshService = deviceMeshService;
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

    public HostsGetChangeCounterResponse? HostsGetChangeCounterResponse
    {
        get => hostsGetChangeCounterResponse;
        private set { _ = SetProperty(ref hostsGetChangeCounterResponse, value); }
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
                GetHostsGetMeshListPathAsync(cancellationToken),
                GetHostsGetHostNumberOfEntriesAsync(),
                GetHostsGetChangeCounterAsync()
            });
    }

    private async Task GetHostsGetHostNumberOfEntriesAsync()
    {
        HostsGetHostNumberOfEntriesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.HostsGetHostNumberOfEntriesAsync();
    }

    private async Task GetHostsGetChangeCounterAsync()
    {
        HostsGetChangeCounterResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.HostsGetChangeCounterAsync();
    }

    private async Task GetHostsGetHostListPathAsync(CancellationToken cancellationToken)
    {
        HostsGetHostListPathResponse newHostsGetHostListPathResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.HostsGetHostListPathAsync();
        string hostListPath = newHostsGetHostListPathResponse.HostListPath;
        var hostListPathUri = new Uri(FormattableString.Invariant($"https://{DeviceLoginInfo.InternetGatewayDevice.ApiDevice.PreferredLocation.Host}:{DeviceLoginInfo.InternetGatewayDevice.ApiDevice.SecurityPort}{hostListPath}"));
        IEnumerable<DeviceHost> deviceHosts = await deviceHostsService.GetDeviceHostsAsync(hostListPathUri, cancellationToken);

        DeviceHostInfo = new DeviceHostInfo(hostListPath, hostListPathUri, new ObservableCollection<DeviceHost>(deviceHosts));
    }

    private async Task GetHostsGetMeshListPathAsync(CancellationToken cancellationToken)
    {
        HostsGetMeshListPathResponse newHostsGetMeshListPathResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.HostsGetMeshListPathAsync();
        string meshListPath = newHostsGetMeshListPathResponse.MeshListPath;
        var meshListPathUri = new Uri(FormattableString.Invariant($"https://{DeviceLoginInfo.InternetGatewayDevice.ApiDevice.PreferredLocation.Host}:{DeviceLoginInfo.InternetGatewayDevice.ApiDevice.SecurityPort}{meshListPath}"));
        DeviceMesh deviceMesh = await deviceMeshService.GetDeviceMeshAsync(meshListPathUri, cancellationToken);
    }
}
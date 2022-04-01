namespace RS.Fritz.Manager.UI;

internal sealed class HostsViewModel : FritzServiceViewModel
{
    private readonly IDeviceHostsService deviceHostsService;
    private readonly IDeviceMeshService deviceMeshService;

    private KeyValuePair<HostsGetHostNumberOfEntriesResponse?, UPnPFault?>? hostsGetHostNumberOfEntriesResponse;
    private KeyValuePair<HostsGetChangeCounterResponse?, UPnPFault?>? hostsGetChangeCounterResponse;
    private DeviceHostInfo? deviceHostInfo;
    private DeviceMeshInfo? deviceMeshInfo;

    public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IDeviceHostsService deviceHostsService, IDeviceMeshService deviceMeshService, HostsGetGenericHostEntryViewModel hostsGetGenericHostEntryViewModel)
        : base(deviceLoginInfo, logger, "Hosts")
    {
        HostsGetGenericHostEntryViewModel = hostsGetGenericHostEntryViewModel;
        this.deviceHostsService = deviceHostsService;
        this.deviceMeshService = deviceMeshService;
    }

    public HostsGetGenericHostEntryViewModel HostsGetGenericHostEntryViewModel { get; }

    public KeyValuePair<HostsGetHostNumberOfEntriesResponse?, UPnPFault?>? HostsGetHostNumberOfEntriesResponse
    {
        get => hostsGetHostNumberOfEntriesResponse;
        private set
        {
            if (SetProperty(ref hostsGetHostNumberOfEntriesResponse, value))
                HostsGetGenericHostEntryViewModel.HostNumberOfEntries = HostsGetHostNumberOfEntriesResponse?.Key?.HostNumberOfEntries;
        }
    }

    public KeyValuePair<HostsGetChangeCounterResponse?, UPnPFault?>? HostsGetChangeCounterResponse
    {
        get => hostsGetChangeCounterResponse;
        private set { _ = SetProperty(ref hostsGetChangeCounterResponse, value); }
    }

    public DeviceHostInfo? DeviceHostInfo
    {
        get => deviceHostInfo;
        private set { _ = SetProperty(ref deviceHostInfo, value); }
    }

    public DeviceMeshInfo? DeviceMeshInfo
    {
        get => deviceMeshInfo;
        private set { _ = SetProperty(ref deviceMeshInfo, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
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
        HostsGetHostNumberOfEntriesResponse = await ExecuteApiAsync(q => q.HostsGetHostNumberOfEntriesAsync());
    }

    private async Task GetHostsGetChangeCounterAsync()
    {
        HostsGetChangeCounterResponse = await ExecuteApiAsync(q => q.HostsGetChangeCounterAsync());
    }

    private async Task GetHostsGetHostListPathAsync(CancellationToken cancellationToken)
    {
        DeviceHostInfo = await deviceHostsService.GetDeviceHostsAsync(ApiDevice, cancellationToken);
    }

    private async Task GetHostsGetMeshListPathAsync(CancellationToken cancellationToken)
    {
        DeviceMeshInfo = await deviceMeshService.GetDeviceMeshAsync(ApiDevice, cancellationToken);
    }
}
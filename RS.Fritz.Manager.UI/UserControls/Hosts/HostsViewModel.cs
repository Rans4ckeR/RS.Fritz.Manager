namespace RS.Fritz.Manager.UI;

internal sealed class HostsViewModel : FritzServiceViewModel
{
    private readonly IDeviceHostsService deviceHostsService;
    private readonly IDeviceMeshService deviceMeshService;

    private HostsGetHostNumberOfEntriesResponse? hostsGetHostNumberOfEntriesResponse;
    private HostsGetChangeCounterResponse? hostsGetChangeCounterResponse;
    private DeviceHostInfo? deviceHostInfo;
    private DeviceMeshInfo? deviceMeshInfo;

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

    public DeviceMeshInfo? DeviceMeshInfo
    {
        get => deviceMeshInfo;
        private set { _ = SetProperty(ref deviceMeshInfo, value); }
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
        DeviceHostInfo = await deviceHostsService.GetDeviceHostsAsync(DeviceLoginInfo.InternetGatewayDevice!.ApiDevice, cancellationToken);
    }

    private async Task GetHostsGetMeshListPathAsync(CancellationToken cancellationToken)
    {
        DeviceMeshInfo = await deviceMeshService.GetDeviceMeshAsync(DeviceLoginInfo.InternetGatewayDevice!.ApiDevice, cancellationToken);
    }
}
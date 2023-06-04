namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;

internal sealed class HostsViewModel : FritzServiceViewModel
{
    private readonly IDeviceHostsService deviceHostsService;
    private readonly IDeviceMeshService deviceMeshService;

    private KeyValuePair<HostsGetHostNumberOfEntriesResponse?, UPnPFault?>? hostsGetHostNumberOfEntriesResponse;
    private KeyValuePair<HostsGetInfoResponse?, UPnPFault?>? hostsGetInfoResponse;
    private KeyValuePair<HostsGetChangeCounterResponse?, UPnPFault?>? hostsGetChangeCounterResponse;
    private KeyValuePair<HostsGetFriendlyNameResponse?, UPnPFault?>? hostsGetFriendlyNameResponse;
    private DeviceHostInfo? deviceHostInfo;
    private DeviceMeshInfo? deviceMeshInfo;
    private ObservableCollection<HostsGetGenericHostEntryResponse>? hostsGetGenericHostEntryResponses;

    public HostsViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IDeviceHostsService deviceHostsService, IDeviceMeshService deviceMeshService, HostsGetGenericHostEntryViewModel hostsGetGenericHostEntryViewModel, HostsHostsCheckUpdateViewModel hostsHostsCheckUpdateViewModel)
        : base(deviceLoginInfo, logger, "Hosts")
    {
        HostsGetGenericHostEntryViewModel = hostsGetGenericHostEntryViewModel;
        HostsHostsCheckUpdateViewModel = hostsHostsCheckUpdateViewModel;
        this.deviceHostsService = deviceHostsService;
        this.deviceMeshService = deviceMeshService;
    }

    public HostsGetGenericHostEntryViewModel HostsGetGenericHostEntryViewModel { get; }

    public HostsHostsCheckUpdateViewModel HostsHostsCheckUpdateViewModel { get; }

    public KeyValuePair<HostsGetHostNumberOfEntriesResponse?, UPnPFault?>? HostsGetHostNumberOfEntriesResponse
    {
        get => hostsGetHostNumberOfEntriesResponse;
        private set
        {
            if (SetProperty(ref hostsGetHostNumberOfEntriesResponse, value))
                HostsGetGenericHostEntryViewModel.HostNumberOfEntries = HostsGetHostNumberOfEntriesResponse?.Key?.HostNumberOfEntries;
        }
    }

    public KeyValuePair<HostsGetInfoResponse?, UPnPFault?>? HostsGetInfoResponse
    {
        get => hostsGetInfoResponse;
        private set => _ = SetProperty(ref hostsGetInfoResponse, value);
    }

    public KeyValuePair<HostsGetChangeCounterResponse?, UPnPFault?>? HostsGetChangeCounterResponse
    {
        get => hostsGetChangeCounterResponse;
        private set => _ = SetProperty(ref hostsGetChangeCounterResponse, value);
    }

    public KeyValuePair<HostsGetFriendlyNameResponse?, UPnPFault?>? HostsGetFriendlyNameResponse
    {
        get => hostsGetFriendlyNameResponse;
        private set => _ = SetProperty(ref hostsGetFriendlyNameResponse, value);
    }

    public DeviceHostInfo? DeviceHostInfo
    {
        get => deviceHostInfo;
        private set => _ = SetProperty(ref deviceHostInfo, value);
    }

    public DeviceMeshInfo? DeviceMeshInfo
    {
        get => deviceMeshInfo;
        private set => _ = SetProperty(ref deviceMeshInfo, value);
    }

    public ObservableCollection<HostsGetGenericHostEntryResponse>? HostsGetGenericHostEntryResponses
    {
        get => hostsGetGenericHostEntryResponses;
        private set => _ = SetProperty(ref hostsGetGenericHostEntryResponses, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(
            new[]
            {
                GetHostsGetHostListPathAsync(cancellationToken),
                GetHostsGetMeshListPathAsync(cancellationToken),
                GetHostsGetHostNumberOfEntriesAsync(),
                GetHostsGetInfoAsync(),
                GetHostsGetChangeCounterAsync(),
                GetHostsGetFriendlyNameAsync()
            },
            true);
    }

    private async Task GetHostsGetHostNumberOfEntriesAsync()
    {
        HostsGetHostNumberOfEntriesResponse = await ExecuteApiAsync(q => q.HostsGetHostNumberOfEntriesAsync()).ConfigureAwait(true);

        ushort numberOfEntries = HostsGetHostNumberOfEntriesResponse!.Value.Key!.Value.HostNumberOfEntries;
        var tasks = new List<Task<KeyValuePair<HostsGetGenericHostEntryResponse?, UPnPFault?>>>();

        for (ushort i = 0; i < numberOfEntries; i++)
        {
            ushort capturedIndex = i;

            tasks.Add(ExecuteApiAsync(q => q.HostsGetGenericHostEntryAsync(new(capturedIndex))));
        }

        KeyValuePair<HostsGetGenericHostEntryResponse?, UPnPFault?>[] responses = await API.TaskExtensions.WhenAllSafe(tasks, true).ConfigureAwait(true);

        HostsGetGenericHostEntryResponses = new(responses.Select(q => q.Key!.Value));
    }

    private async Task GetHostsGetInfoAsync()
        => HostsGetInfoResponse = await ExecuteApiAsync(q => q.HostsGetInfoAsync()).ConfigureAwait(true);

    private async Task GetHostsGetChangeCounterAsync()
        => HostsGetChangeCounterResponse = await ExecuteApiAsync(q => q.HostsGetChangeCounterAsync()).ConfigureAwait(true);

    private async Task GetHostsGetFriendlyNameAsync()
        => HostsGetFriendlyNameResponse = await ExecuteApiAsync(q => q.HostsGetFriendlyNameAsync()).ConfigureAwait(true);

    private async Task GetHostsGetHostListPathAsync(CancellationToken cancellationToken)
        => DeviceHostInfo = await deviceHostsService.GetDeviceHostsAsync(ApiDevice, cancellationToken).ConfigureAwait(true);

    private async Task GetHostsGetMeshListPathAsync(CancellationToken cancellationToken)
        => DeviceMeshInfo = await deviceMeshService.GetDeviceMeshAsync(ApiDevice, cancellationToken).ConfigureAwait(true);
}
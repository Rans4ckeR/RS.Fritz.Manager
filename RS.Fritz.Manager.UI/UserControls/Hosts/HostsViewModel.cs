using System.Collections.ObjectModel;

namespace RS.Fritz.Manager.UI;

internal sealed class HostsViewModel(
    DeviceLoginInfo deviceLoginInfo,
    ILogger logger,
    IDeviceHostsService deviceHostsService,
    IDeviceMeshService deviceMeshService,
    HostsGetGenericHostEntryViewModel hostsGetGenericHostEntryViewModel,
    HostsHostsCheckUpdateViewModel hostsHostsCheckUpdateViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "Hosts")
{
    private readonly IDeviceHostsService deviceHostsService = deviceHostsService;
    private readonly IDeviceMeshService deviceMeshService = deviceMeshService;

    public HostsGetGenericHostEntryViewModel HostsGetGenericHostEntryViewModel { get; } = hostsGetGenericHostEntryViewModel;

    public HostsHostsCheckUpdateViewModel HostsHostsCheckUpdateViewModel { get; } = hostsHostsCheckUpdateViewModel;

    public KeyValuePair<HostsGetHostNumberOfEntriesResponse?, UPnPFault?>? HostsGetHostNumberOfEntriesResponse
    {
        get;
        private set
        {
            if (SetProperty(ref field, value))
                HostsGetGenericHostEntryViewModel.HostNumberOfEntries = HostsGetHostNumberOfEntriesResponse?.Key?.HostNumberOfEntries;
        }
    }

    public KeyValuePair<HostsGetInfoResponse?, UPnPFault?>? HostsGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<HostsGetChangeCounterResponse?, UPnPFault?>? HostsGetChangeCounterResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<HostsGetFriendlyNameResponse?, UPnPFault?>? HostsGetFriendlyNameResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public DeviceHostInfo? DeviceHostInfo
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public DeviceMeshInfo? DeviceMeshInfo
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public ObservableCollection<HostsGetGenericHostEntryResponse>? HostsGetGenericHostEntryResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => API.TaskExtensions.WhenAllSafe(
            [
                GetHostsGetHostListPathAsync(cancellationToken),
                GetHostsGetMeshListPathAsync(cancellationToken),
                GetHostsGetHostNumberOfEntriesAsync(),
                GetHostsGetInfoAsync(),
                GetHostsGetChangeCounterAsync(),
                GetHostsGetFriendlyNameAsync()
            ],
            true);

    private async Task GetHostsGetHostNumberOfEntriesAsync()
    {
        HostsGetHostNumberOfEntriesResponse = await ExecuteApiAsync(static q => q.HostsGetHostNumberOfEntriesAsync()).ConfigureAwait(true);

        ushort numberOfEntries = HostsGetHostNumberOfEntriesResponse!.Value.Key!.Value.HostNumberOfEntries;
        var tasks = new List<Task<KeyValuePair<HostsGetGenericHostEntryResponse?, UPnPFault?>>>();

        for (ushort i = 0; i < numberOfEntries; i++)
        {
            ushort capturedIndex = i;

            tasks.Add(ExecuteApiAsync(q => q.HostsGetGenericHostEntryAsync(new(capturedIndex))));
        }

        KeyValuePair<HostsGetGenericHostEntryResponse?, UPnPFault?>[] responses = await API.TaskExtensions.WhenAllSafe(tasks, true).ConfigureAwait(true);

        HostsGetGenericHostEntryResponses = [.. responses.Select(static q => q.Key!.Value)];
    }

    private async Task GetHostsGetInfoAsync()
        => HostsGetInfoResponse = await ExecuteApiAsync(static q => q.HostsGetInfoAsync()).ConfigureAwait(true);

    private async Task GetHostsGetChangeCounterAsync()
        => HostsGetChangeCounterResponse = await ExecuteApiAsync(static q => q.HostsGetChangeCounterAsync()).ConfigureAwait(true);

    private async Task GetHostsGetFriendlyNameAsync()
        => HostsGetFriendlyNameResponse = await ExecuteApiAsync(static q => q.HostsGetFriendlyNameAsync()).ConfigureAwait(true);

    private async Task GetHostsGetHostListPathAsync(CancellationToken cancellationToken)
        => DeviceHostInfo = await deviceHostsService.GetDeviceHostsAsync(ApiDevice, cancellationToken).ConfigureAwait(true);

    private async Task GetHostsGetMeshListPathAsync(CancellationToken cancellationToken)
        => DeviceMeshInfo = await deviceMeshService.GetDeviceMeshAsync(ApiDevice, cancellationToken).ConfigureAwait(true);
}
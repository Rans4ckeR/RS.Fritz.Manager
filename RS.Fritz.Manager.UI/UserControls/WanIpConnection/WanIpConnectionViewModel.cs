using System.Collections.ObjectModel;

namespace RS.Fritz.Manager.UI;

internal sealed class WanIpConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<WanIpConnectionViewModel> logger, WanIpConnectionGetGenericPortMappingEntryViewModel wanIpConnectionGetGenericPortMappingEntryViewModel)
    : WanAccessTypeAwareFritzServiceViewModel(deviceLoginInfo, logger, WanAccessType.Ethernet, "WANIPConnection")
{
    public WanIpConnectionGetGenericPortMappingEntryViewModel WanIpConnectionGetGenericPortMappingEntryViewModel { get; } = wanIpConnectionGetGenericPortMappingEntryViewModel;

    public KeyValuePair<WanIpConnectionGetInfoResponse?, UPnPFault?>? WanIpConnectionGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanConnectionGetConnectionTypeInfoResponse?, UPnPFault?>? WanConnectionGetConnectionTypeInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanConnectionGetStatusInfoResponse?, UPnPFault?>? WanConnectionGetStatusInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanConnectionGetNatRsipStatusResponse?, UPnPFault?>? WanConnectionGetNatRsipStatusResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanConnectionGetDnsServersResponse?, UPnPFault?>? WanConnectionGetDnsServersResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanConnectionGetPortMappingNumberOfEntriesResponse?, UPnPFault?>? WanConnectionGetPortMappingNumberOfEntriesResponse
    {
        get;
        private set
        {
            if (SetProperty(ref field, value))
                WanIpConnectionGetGenericPortMappingEntryViewModel.PortMappingNumberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse?.Key!.Value.PortMappingNumberOfEntries;
        }
    }

    public KeyValuePair<WanConnectionGetExternalIpAddressResponse?, UPnPFault?>? WanConnectionGetExternalIpAddressResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public ObservableCollection<WanConnectionGetGenericPortMappingEntryResponse>? WanConnectionGetGenericPortMappingEntryResponses
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => API.TaskExtensions.WhenAllSafe(
            [
                GetWanIpConnectionGetInfoAsync(),
                GetWanIpConnectionGetConnectionTypeInfoAsync(),
                GetWanIpConnectionGetStatusInfoAsync(),
                GetWanIpConnectionGetNatRsipStatusAsync(),
                GetWanIpConnectionGetDnsServersAsync(),
                GetWanIpConnectionGetPortMappingNumberOfEntriesAsync(),
                GetWanIpConnectionGetExternalIpAddressAsync()
            ],
            true);

    private async Task GetWanIpConnectionGetInfoAsync()
        => WanIpConnectionGetInfoResponse = await ExecuteApiAsync(static q => q.WanIpConnectionGetInfoAsync()).ConfigureAwait(true);

    private async Task GetWanIpConnectionGetConnectionTypeInfoAsync()
        => WanConnectionGetConnectionTypeInfoResponse = await ExecuteApiAsync(static q => q.WanIpConnectionGetConnectionTypeInfoAsync()).ConfigureAwait(true);

    private async Task GetWanIpConnectionGetStatusInfoAsync()
        => WanConnectionGetStatusInfoResponse = await ExecuteApiAsync(static q => q.WanIpConnectionGetStatusInfoAsync()).ConfigureAwait(true);

    private async Task GetWanIpConnectionGetNatRsipStatusAsync()
        => WanConnectionGetNatRsipStatusResponse = await ExecuteApiAsync(static q => q.WanIpConnectionGetNatRsipStatusAsync()).ConfigureAwait(true);

    private async Task GetWanIpConnectionGetDnsServersAsync()
        => WanConnectionGetDnsServersResponse = await ExecuteApiAsync(static q => q.WanIpConnectionGetDnsServersAsync()).ConfigureAwait(true);

    private async Task GetWanIpConnectionGetPortMappingNumberOfEntriesAsync()
    {
        WanConnectionGetPortMappingNumberOfEntriesResponse = await ExecuteApiAsync(static q => q.WanIpConnectionGetPortMappingNumberOfEntriesAsync()).ConfigureAwait(true);

        ushort numberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse!.Value.Key!.Value.PortMappingNumberOfEntries;
        var tasks = new List<Task<KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>>>();

        for (ushort i = 0; i < numberOfEntries; i++)
        {
            ushort capturedIndex = i;

            tasks.Add(ExecuteApiAsync(q => q.WanIpConnectionGetGenericPortMappingEntryAsync(new(capturedIndex))));
        }

        KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>[] responses = await API.TaskExtensions.WhenAllSafe(tasks, true).ConfigureAwait(true);

        WanConnectionGetGenericPortMappingEntryResponses = [.. responses.Select(static q => q.Key!.Value)];
    }

    private async Task GetWanIpConnectionGetExternalIpAddressAsync()
        => WanConnectionGetExternalIpAddressResponse = await ExecuteApiAsync(static q => q.WanIpConnectionGetExternalIpAddressAsync()).ConfigureAwait(true);
}
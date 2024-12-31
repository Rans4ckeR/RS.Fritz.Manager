using System.Collections.ObjectModel;

namespace RS.Fritz.Manager.UI;

internal sealed class WanPppConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<WanPppConnectionViewModel> logger, WanPppConnectionGetGenericPortMappingEntryViewModel wanPppConnectionGetGenericPortMappingEntryViewModel)
    : WanAccessTypeAwareFritzServiceViewModel(deviceLoginInfo, logger, WanAccessType.Dsl, "WANPPPConnection")
{
    public WanPppConnectionGetGenericPortMappingEntryViewModel WanPppConnectionGetGenericPortMappingEntryViewModel { get; } = wanPppConnectionGetGenericPortMappingEntryViewModel;

    public KeyValuePair<WanPppConnectionGetInfoResponse?, UPnPFault?>? WanPppConnectionGetInfoResponse
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

    public KeyValuePair<WanPppConnectionGetLinkLayerMaxBitRatesResponse?, UPnPFault?>? WanPppConnectionGetLinkLayerMaxBitRatesResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanPppConnectionGetUserNameResponse?, UPnPFault?>? WanPppConnectionGetUserNameResponse
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
                WanPppConnectionGetGenericPortMappingEntryViewModel.PortMappingNumberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse?.Key!.Value.PortMappingNumberOfEntries;
        }
    }

    public KeyValuePair<WanConnectionGetExternalIpAddressResponse?, UPnPFault?>? WanConnectionGetExternalIpAddressResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanPppConnectionGetAutoDisconnectTimeSpanResponse?, UPnPFault?>? WanPppConnectionGetAutoDisconnectTimeSpanResponse
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
                GetWanPppConnectionGetInfoAsync(),
                GetWanPppConnectionGetConnectionTypeInfoAsync(),
                GetWanPppConnectionGetStatusInfoAsync(),
                GetWanPppConnectionGetLinkLayerMaxBitRatesAsync(),
                GetWanPppConnectionGetUserNameAsync(),
                GetWanPppConnectionGetNatRsipStatusAsync(),
                GetWanPppConnectionGetDnsServersAsync(),
                GetWanPppConnectionGetPortMappingNumberOfEntriesAsync(),
                GetWanPppConnectionGetExternalIpAddressAsync(),
                GetWanPppConnectionGetAutoDisconnectTimeSpanAsync()
            ],
            true);

    private async Task GetWanPppConnectionGetInfoAsync()
        => WanPppConnectionGetInfoResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetInfoAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetConnectionTypeInfoAsync()
        => WanConnectionGetConnectionTypeInfoResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetConnectionTypeInfoAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetStatusInfoAsync()
        => WanConnectionGetStatusInfoResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetStatusInfoAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetLinkLayerMaxBitRatesAsync()
        => WanPppConnectionGetLinkLayerMaxBitRatesResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetLinkLayerMaxBitRatesAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetUserNameAsync()
        => WanPppConnectionGetUserNameResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetUserNameAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetNatRsipStatusAsync()
        => WanConnectionGetNatRsipStatusResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetNatRsipStatusAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetDnsServersAsync()
        => WanConnectionGetDnsServersResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetDnsServersAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetPortMappingNumberOfEntriesAsync()
    {
        WanConnectionGetPortMappingNumberOfEntriesResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetPortMappingNumberOfEntriesAsync()).ConfigureAwait(true);

        ushort numberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse!.Value.Key!.Value.PortMappingNumberOfEntries;
        var tasks = new List<Task<KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>>>();

        for (ushort i = 0; i < numberOfEntries; i++)
        {
            ushort capturedIndex = i;

            tasks.Add(ExecuteApiAsync(q => q.WanPppConnectionGetGenericPortMappingEntryAsync(new(capturedIndex))));
        }

        KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>[] responses = await API.TaskExtensions.WhenAllSafe(tasks, true).ConfigureAwait(true);

        WanConnectionGetGenericPortMappingEntryResponses = [.. responses.Select(static q => q.Key!.Value)];
    }

    private async Task GetWanPppConnectionGetExternalIpAddressAsync()
        => WanConnectionGetExternalIpAddressResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetExternalIpAddressAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetAutoDisconnectTimeSpanAsync()
        => WanPppConnectionGetAutoDisconnectTimeSpanResponse = await ExecuteApiAsync(static q => q.WanPppConnectionGetAutoDisconnectTimeSpanAsync()).ConfigureAwait(true);
}
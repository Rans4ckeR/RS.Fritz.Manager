namespace RS.Fritz.Manager.UI;

using System.Collections.ObjectModel;

internal sealed class WanPppConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanPppConnectionGetGenericPortMappingEntryViewModel wanPppConnectionGetGenericPortMappingEntryViewModel)
    : WanAccessTypeAwareFritzServiceViewModel(deviceLoginInfo, logger, WanAccessType.Dsl, "WANPPPConnection")
{
    private KeyValuePair<WanPppConnectionGetInfoResponse?, UPnPFault?>? wanPppConnectionGetInfoResponse;
    private KeyValuePair<WanConnectionGetConnectionTypeInfoResponse?, UPnPFault?>? wanConnectionGetConnectionTypeInfoResponse;
    private KeyValuePair<WanConnectionGetStatusInfoResponse?, UPnPFault?>? wanConnectionGetStatusInfoResponse;
    private KeyValuePair<WanPppConnectionGetLinkLayerMaxBitRatesResponse?, UPnPFault?>? wanPppConnectionGetLinkLayerMaxBitRatesResponse;
    private KeyValuePair<WanPppConnectionGetUserNameResponse?, UPnPFault?>? wanPppConnectionGetUserNameResponse;
    private KeyValuePair<WanConnectionGetNatRsipStatusResponse?, UPnPFault?>? wanConnectionGetNatRsipStatusResponse;
    private KeyValuePair<WanConnectionGetDnsServersResponse?, UPnPFault?>? wanConnectionGetDnsServersResponse;
    private KeyValuePair<WanConnectionGetPortMappingNumberOfEntriesResponse?, UPnPFault?>? wanConnectionGetPortMappingNumberOfEntriesResponse;
    private KeyValuePair<WanConnectionGetExternalIpAddressResponse?, UPnPFault?>? wanConnectionGetExternalIpAddressResponse;
    private KeyValuePair<WanPppConnectionGetAutoDisconnectTimeSpanResponse?, UPnPFault?>? wanPppConnectionGetAutoDisconnectTimeSpanResponse;
    private ObservableCollection<WanConnectionGetGenericPortMappingEntryResponse>? wanConnectionGetGenericPortMappingEntryResponses;

    public WanPppConnectionGetGenericPortMappingEntryViewModel WanPppConnectionGetGenericPortMappingEntryViewModel { get; } = wanPppConnectionGetGenericPortMappingEntryViewModel;

    public KeyValuePair<WanPppConnectionGetInfoResponse?, UPnPFault?>? WanPppConnectionGetInfoResponse
    {
        get => wanPppConnectionGetInfoResponse;
        private set => _ = SetProperty(ref wanPppConnectionGetInfoResponse, value);
    }

    public KeyValuePair<WanConnectionGetConnectionTypeInfoResponse?, UPnPFault?>? WanConnectionGetConnectionTypeInfoResponse
    {
        get => wanConnectionGetConnectionTypeInfoResponse;
        private set => _ = SetProperty(ref wanConnectionGetConnectionTypeInfoResponse, value);
    }

    public KeyValuePair<WanConnectionGetStatusInfoResponse?, UPnPFault?>? WanConnectionGetStatusInfoResponse
    {
        get => wanConnectionGetStatusInfoResponse;
        private set => _ = SetProperty(ref wanConnectionGetStatusInfoResponse, value);
    }

    public KeyValuePair<WanPppConnectionGetLinkLayerMaxBitRatesResponse?, UPnPFault?>? WanPppConnectionGetLinkLayerMaxBitRatesResponse
    {
        get => wanPppConnectionGetLinkLayerMaxBitRatesResponse;
        private set => _ = SetProperty(ref wanPppConnectionGetLinkLayerMaxBitRatesResponse, value);
    }

    public KeyValuePair<WanPppConnectionGetUserNameResponse?, UPnPFault?>? WanPppConnectionGetUserNameResponse
    {
        get => wanPppConnectionGetUserNameResponse;
        private set => _ = SetProperty(ref wanPppConnectionGetUserNameResponse, value);
    }

    public KeyValuePair<WanConnectionGetNatRsipStatusResponse?, UPnPFault?>? WanConnectionGetNatRsipStatusResponse
    {
        get => wanConnectionGetNatRsipStatusResponse;
        private set => _ = SetProperty(ref wanConnectionGetNatRsipStatusResponse, value);
    }

    public KeyValuePair<WanConnectionGetDnsServersResponse?, UPnPFault?>? WanConnectionGetDnsServersResponse
    {
        get => wanConnectionGetDnsServersResponse;
        private set => _ = SetProperty(ref wanConnectionGetDnsServersResponse, value);
    }

    public KeyValuePair<WanConnectionGetPortMappingNumberOfEntriesResponse?, UPnPFault?>? WanConnectionGetPortMappingNumberOfEntriesResponse
    {
        get => wanConnectionGetPortMappingNumberOfEntriesResponse;
        private set
        {
            if (SetProperty(ref wanConnectionGetPortMappingNumberOfEntriesResponse, value))
                WanPppConnectionGetGenericPortMappingEntryViewModel.PortMappingNumberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse?.Key!.Value.PortMappingNumberOfEntries;
        }
    }

    public KeyValuePair<WanConnectionGetExternalIpAddressResponse?, UPnPFault?>? WanConnectionGetExternalIpAddressResponse
    {
        get => wanConnectionGetExternalIpAddressResponse;
        private set => _ = SetProperty(ref wanConnectionGetExternalIpAddressResponse, value);
    }

    public KeyValuePair<WanPppConnectionGetAutoDisconnectTimeSpanResponse?, UPnPFault?>? WanPppConnectionGetAutoDisconnectTimeSpanResponse
    {
        get => wanPppConnectionGetAutoDisconnectTimeSpanResponse;
        private set => _ = SetProperty(ref wanPppConnectionGetAutoDisconnectTimeSpanResponse, value);
    }

    public ObservableCollection<WanConnectionGetGenericPortMappingEntryResponse>? WanConnectionGetGenericPortMappingEntryResponses
    {
        get => wanConnectionGetGenericPortMappingEntryResponses;
        private set => _ = SetProperty(ref wanConnectionGetGenericPortMappingEntryResponses, value);
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
        => WanPppConnectionGetInfoResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetInfoAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetConnectionTypeInfoAsync()
        => WanConnectionGetConnectionTypeInfoResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetConnectionTypeInfoAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetStatusInfoAsync()
        => WanConnectionGetStatusInfoResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetStatusInfoAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetLinkLayerMaxBitRatesAsync()
        => WanPppConnectionGetLinkLayerMaxBitRatesResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetLinkLayerMaxBitRatesAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetUserNameAsync()
        => WanPppConnectionGetUserNameResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetUserNameAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetNatRsipStatusAsync()
        => WanConnectionGetNatRsipStatusResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetNatRsipStatusAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetDnsServersAsync()
        => WanConnectionGetDnsServersResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetDnsServersAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetPortMappingNumberOfEntriesAsync()
    {
        WanConnectionGetPortMappingNumberOfEntriesResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetPortMappingNumberOfEntriesAsync()).ConfigureAwait(true);

        ushort numberOfEntries = WanConnectionGetPortMappingNumberOfEntriesResponse!.Value.Key!.Value.PortMappingNumberOfEntries;
        var tasks = new List<Task<KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>>>();

        for (ushort i = 0; i < numberOfEntries; i++)
        {
            ushort capturedIndex = i;

            tasks.Add(ExecuteApiAsync(q => q.WanPppConnectionGetGenericPortMappingEntryAsync(new(capturedIndex))));
        }

        KeyValuePair<WanConnectionGetGenericPortMappingEntryResponse?, UPnPFault?>[] responses = await API.TaskExtensions.WhenAllSafe(tasks, true).ConfigureAwait(true);

        WanConnectionGetGenericPortMappingEntryResponses = new(responses.Select(q => q.Key!.Value));
    }

    private async Task GetWanPppConnectionGetExternalIpAddressAsync()
        => WanConnectionGetExternalIpAddressResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetExternalIpAddressAsync()).ConfigureAwait(true);

    private async Task GetWanPppConnectionGetAutoDisconnectTimeSpanAsync()
        => WanPppConnectionGetAutoDisconnectTimeSpanResponse = await ExecuteApiAsync(q => q.WanPppConnectionGetAutoDisconnectTimeSpanAsync()).ConfigureAwait(true);
}
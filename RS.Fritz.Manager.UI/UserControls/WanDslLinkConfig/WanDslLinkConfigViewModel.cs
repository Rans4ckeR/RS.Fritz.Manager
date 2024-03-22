namespace RS.Fritz.Manager.UI;

internal sealed class WanDslLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : WanAccessTypeAwareFritzServiceViewModel(deviceLoginInfo, logger, WanAccessType.Dsl, "WANDSLLinkConfig")
{
    private KeyValuePair<WanDslLinkConfigGetInfoResponse?, UPnPFault?>? wanDslLinkConfigGetInfoResponse;
    private KeyValuePair<WanDslLinkConfigGetDslLinkInfoResponse?, UPnPFault?>? wanDslLinkConfigGetDslLinkInfoResponse;
    private KeyValuePair<WanDslLinkConfigGetDestinationAddressResponse?, UPnPFault?>? wanDslLinkConfigGetDestinationAddressResponse;
    private KeyValuePair<WanDslLinkConfigGetAtmEncapsulationResponse?, UPnPFault?>? wanDslLinkConfigGetAtmEncapsulationResponse;
    private KeyValuePair<WanDslLinkConfigGetAutoConfigResponse?, UPnPFault?>? wanDslLinkConfigGetAutoConfigResponse;
    private KeyValuePair<WanDslLinkConfigGetStatisticsResponse?, UPnPFault?>? wanDslLinkConfigGetStatisticsResponse;

    public KeyValuePair<WanDslLinkConfigGetInfoResponse?, UPnPFault?>? WanDslLinkConfigGetInfoResponse
    {
        get => wanDslLinkConfigGetInfoResponse;
        private set => _ = SetProperty(ref wanDslLinkConfigGetInfoResponse, value);
    }

    public KeyValuePair<WanDslLinkConfigGetDslLinkInfoResponse?, UPnPFault?>? WanDslLinkConfigGetDslLinkInfoResponse
    {
        get => wanDslLinkConfigGetDslLinkInfoResponse;
        private set => _ = SetProperty(ref wanDslLinkConfigGetDslLinkInfoResponse, value);
    }

    public KeyValuePair<WanDslLinkConfigGetDestinationAddressResponse?, UPnPFault?>? WanDslLinkConfigGetDestinationAddressResponse
    {
        get => wanDslLinkConfigGetDestinationAddressResponse;
        private set => _ = SetProperty(ref wanDslLinkConfigGetDestinationAddressResponse, value);
    }

    public KeyValuePair<WanDslLinkConfigGetAtmEncapsulationResponse?, UPnPFault?>? WanDslLinkConfigGetAtmEncapsulationResponse
    {
        get => wanDslLinkConfigGetAtmEncapsulationResponse;
        private set => _ = SetProperty(ref wanDslLinkConfigGetAtmEncapsulationResponse, value);
    }

    public KeyValuePair<WanDslLinkConfigGetAutoConfigResponse?, UPnPFault?>? WanDslLinkConfigGetAutoConfigResponse
    {
        get => wanDslLinkConfigGetAutoConfigResponse;
        private set => _ = SetProperty(ref wanDslLinkConfigGetAutoConfigResponse, value);
    }

    public KeyValuePair<WanDslLinkConfigGetStatisticsResponse?, UPnPFault?>? WanDslLinkConfigGetStatisticsResponse
    {
        get => wanDslLinkConfigGetStatisticsResponse;
        private set => _ = SetProperty(ref wanDslLinkConfigGetStatisticsResponse, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => API.TaskExtensions.WhenAllSafe(
            [
                GetWanDslLinkConfigGetInfoAsync(),
                GetWanDslLinkConfigGetDslLinkInfoAsync(),
                GetWanDslLinkConfigGetDestinationAddressAsync(),
                GetWanDslLinkConfigGetAtmEncapsulationAsync(),
                GetWanDslLinkConfigGetAutoConfigAsync(),
                GetWanDslLinkConfigGetStatisticsAsync()
            ],
            true);

    private async Task GetWanDslLinkConfigGetInfoAsync()
        => WanDslLinkConfigGetInfoResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetInfoAsync()).ConfigureAwait(true);

    private async Task GetWanDslLinkConfigGetDslLinkInfoAsync()
        => WanDslLinkConfigGetDslLinkInfoResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetDslLinkInfoAsync()).ConfigureAwait(true);

    private async Task GetWanDslLinkConfigGetDestinationAddressAsync()
        => WanDslLinkConfigGetDestinationAddressResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetDestinationAddressAsync()).ConfigureAwait(true);

    private async Task GetWanDslLinkConfigGetAtmEncapsulationAsync()
        => WanDslLinkConfigGetAtmEncapsulationResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetAtmEncapsulationAsync()).ConfigureAwait(true);

    private async Task GetWanDslLinkConfigGetAutoConfigAsync()
        => WanDslLinkConfigGetAutoConfigResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetAutoConfigAsync()).ConfigureAwait(true);

    private async Task GetWanDslLinkConfigGetStatisticsAsync()
        => WanDslLinkConfigGetStatisticsResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetStatisticsAsync()).ConfigureAwait(true);
}
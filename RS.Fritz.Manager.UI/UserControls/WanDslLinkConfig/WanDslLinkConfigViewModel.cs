﻿namespace RS.Fritz.Manager.UI;

internal sealed class WanDslLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : WanAccessTypeAwareFritzServiceViewModel(deviceLoginInfo, logger, WanAccessType.Dsl, "WANDSLLinkConfig")
{
    public KeyValuePair<WanDslLinkConfigGetInfoResponse?, UPnPFault?>? WanDslLinkConfigGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanDslLinkConfigGetDslLinkInfoResponse?, UPnPFault?>? WanDslLinkConfigGetDslLinkInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanDslLinkConfigGetDestinationAddressResponse?, UPnPFault?>? WanDslLinkConfigGetDestinationAddressResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanDslLinkConfigGetAtmEncapsulationResponse?, UPnPFault?>? WanDslLinkConfigGetAtmEncapsulationResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanDslLinkConfigGetAutoConfigResponse?, UPnPFault?>? WanDslLinkConfigGetAutoConfigResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanDslLinkConfigGetStatisticsResponse?, UPnPFault?>? WanDslLinkConfigGetStatisticsResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
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
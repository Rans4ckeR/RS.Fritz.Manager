namespace RS.Fritz.Manager.UI;

internal sealed class WanDslLinkConfigViewModel : WanAccessTypeAwareFritzServiceViewModel
{
    private KeyValuePair<WanDslLinkConfigGetInfoResponse?, UPnPFault?>? wanDslLinkConfigGetInfoResponse;
    private KeyValuePair<WanDslLinkConfigGetDslLinkInfoResponse?, UPnPFault?>? wanDslLinkConfigGetDslLinkInfoResponse;
    private KeyValuePair<WanDslLinkConfigGetDestinationAddressResponse?, UPnPFault?>? wanDslLinkConfigGetDestinationAddressResponse;
    private KeyValuePair<WanDslLinkConfigGetAtmEncapsulationResponse?, UPnPFault?>? wanDslLinkConfigGetAtmEncapsulationResponse;
    private KeyValuePair<WanDslLinkConfigGetAutoConfigResponse?, UPnPFault?>? wanDslLinkConfigGetAutoConfigResponse;
    private KeyValuePair<WanDslLinkConfigGetStatisticsResponse?, UPnPFault?>? wanDslLinkConfigGetStatisticsResponse;

    public WanDslLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, WanAccessType.Dsl, "WANDSLLinkConfig")
    {
    }

    public KeyValuePair<WanDslLinkConfigGetInfoResponse?, UPnPFault?>? WanDslLinkConfigGetInfoResponse
    {
        get => wanDslLinkConfigGetInfoResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetInfoResponse, value); }
    }

    public KeyValuePair<WanDslLinkConfigGetDslLinkInfoResponse?, UPnPFault?>? WanDslLinkConfigGetDslLinkInfoResponse
    {
        get => wanDslLinkConfigGetDslLinkInfoResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetDslLinkInfoResponse, value); }
    }

    public KeyValuePair<WanDslLinkConfigGetDestinationAddressResponse?, UPnPFault?>? WanDslLinkConfigGetDestinationAddressResponse
    {
        get => wanDslLinkConfigGetDestinationAddressResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetDestinationAddressResponse, value); }
    }

    public KeyValuePair<WanDslLinkConfigGetAtmEncapsulationResponse?, UPnPFault?>? WanDslLinkConfigGetAtmEncapsulationResponse
    {
        get => wanDslLinkConfigGetAtmEncapsulationResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetAtmEncapsulationResponse, value); }
    }

    public KeyValuePair<WanDslLinkConfigGetAutoConfigResponse?, UPnPFault?>? WanDslLinkConfigGetAutoConfigResponse
    {
        get => wanDslLinkConfigGetAutoConfigResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetAutoConfigResponse, value); }
    }

    public KeyValuePair<WanDslLinkConfigGetStatisticsResponse?, UPnPFault?>? WanDslLinkConfigGetStatisticsResponse
    {
        get => wanDslLinkConfigGetStatisticsResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetStatisticsResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
          {
                GetWanDslLinkConfigGetInfoAsync(),
                GetWanDslLinkConfigGetDslLinkInfoAsync(),
                GetWanDslLinkConfigGetDestinationAddressAsync(),
                GetWanDslLinkConfigGetAtmEncapsulationAsync(),
                GetWanDslLinkConfigGetAutoConfigAsync(),
                GetWanDslLinkConfigGetStatisticsAsync()
          });
    }

    private async Task GetWanDslLinkConfigGetInfoAsync()
    {
        WanDslLinkConfigGetInfoResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetInfoAsync());
    }

    private async Task GetWanDslLinkConfigGetDslLinkInfoAsync()
    {
        WanDslLinkConfigGetDslLinkInfoResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetDslLinkInfoAsync());
    }

    private async Task GetWanDslLinkConfigGetDestinationAddressAsync()
    {
        WanDslLinkConfigGetDestinationAddressResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetDestinationAddressAsync());
    }

    private async Task GetWanDslLinkConfigGetAtmEncapsulationAsync()
    {
        WanDslLinkConfigGetAtmEncapsulationResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetAtmEncapsulationAsync());
    }

    private async Task GetWanDslLinkConfigGetAutoConfigAsync()
    {
        WanDslLinkConfigGetAutoConfigResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetAutoConfigAsync());
    }

    private async Task GetWanDslLinkConfigGetStatisticsAsync()
    {
        WanDslLinkConfigGetStatisticsResponse = await ExecuteApiAsync(q => q.WanDslLinkConfigGetStatisticsAsync());
    }
}
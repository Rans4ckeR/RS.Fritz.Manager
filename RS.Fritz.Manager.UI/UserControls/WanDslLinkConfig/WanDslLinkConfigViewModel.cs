namespace RS.Fritz.Manager.UI;

internal sealed class WanDslLinkConfigViewModel : WanAccessTypeAwareFritzServiceViewModel
{
    private WanDslLinkConfigGetInfoResponse? wanDslLinkConfigGetInfoResponse;
    private WanDslLinkConfigGetDslLinkInfoResponse? wanDslLinkConfigGetDslLinkInfoResponse;
    private WanDslLinkConfigGetDestinationAddressResponse? wanDslLinkConfigGetDestinationAddressResponse;
    private WanDslLinkConfigGetAtmEncapsulationResponse? wanDslLinkConfigGetAtmEncapsulationResponse;
    private WanDslLinkConfigGetAutoConfigResponse? wanDslLinkConfigGetAutoConfigResponse;
    private WanDslLinkConfigGetStatisticsResponse? wanDslLinkConfigGetStatisticsResponse;

    public WanDslLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, WanAccessType.Dsl, "WANDSLLinkConfig")
    {
    }

    public WanDslLinkConfigGetInfoResponse? WanDslLinkConfigGetInfoResponse
    {
        get => wanDslLinkConfigGetInfoResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetInfoResponse, value); }
    }

    public WanDslLinkConfigGetDslLinkInfoResponse? WanDslLinkConfigGetDslLinkInfoResponse
    {
        get => wanDslLinkConfigGetDslLinkInfoResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetDslLinkInfoResponse, value); }
    }

    public WanDslLinkConfigGetDestinationAddressResponse? WanDslLinkConfigGetDestinationAddressResponse
    {
        get => wanDslLinkConfigGetDestinationAddressResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetDestinationAddressResponse, value); }
    }

    public WanDslLinkConfigGetAtmEncapsulationResponse? WanDslLinkConfigGetAtmEncapsulationResponse
    {
        get => wanDslLinkConfigGetAtmEncapsulationResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetAtmEncapsulationResponse, value); }
    }

    public WanDslLinkConfigGetAutoConfigResponse? WanDslLinkConfigGetAutoConfigResponse
    {
        get => wanDslLinkConfigGetAutoConfigResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetAutoConfigResponse, value); }
    }

    public WanDslLinkConfigGetStatisticsResponse? WanDslLinkConfigGetStatisticsResponse
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
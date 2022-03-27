namespace RS.Fritz.Manager.UI;

internal sealed class LanEthernetInterfaceConfigViewModel : FritzServiceViewModel
{
    private LanEthernetInterfaceConfigGetInfoResponse? lanEthernetInterfaceConfigGetInfoResponse;
    private LanEthernetInterfaceConfigGetStatisticsResponse? lanEthernetInterfaceConfigGetStatisticsResponse;

    public LanEthernetInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "LANEthernetInterfaceConfig")
    {
    }

    public LanEthernetInterfaceConfigGetInfoResponse? LanEthernetInterfaceConfigGetInfoResponse
    {
        get => lanEthernetInterfaceConfigGetInfoResponse;
        private set { _ = SetProperty(ref lanEthernetInterfaceConfigGetInfoResponse, value); }
    }

    public LanEthernetInterfaceConfigGetStatisticsResponse? LanEthernetInterfaceConfigGetStatisticsResponse
    {
        get => lanEthernetInterfaceConfigGetStatisticsResponse;
        private set { _ = SetProperty(ref lanEthernetInterfaceConfigGetStatisticsResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetLanEthernetInterfaceConfigGetInfoAsync(),
                GetLanEthernetInterfaceConfigGetStatisticsAsync()
            });
    }

    private async Task GetLanEthernetInterfaceConfigGetInfoAsync()
    {
        LanEthernetInterfaceConfigGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanEthernetInterfaceConfigGetInfoAsync();
    }

    private async Task GetLanEthernetInterfaceConfigGetStatisticsAsync()
    {
        LanEthernetInterfaceConfigGetStatisticsResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanEthernetInterfaceConfigGetStatisticsAsync();
    }
}
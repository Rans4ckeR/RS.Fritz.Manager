namespace RS.Fritz.Manager.UI;

internal sealed class LanEthernetInterfaceConfigViewModel : FritzServiceViewModel
{
    private KeyValuePair<LanEthernetInterfaceConfigGetInfoResponse?, UPnPFault?>? lanEthernetInterfaceConfigGetInfoResponse;
    private KeyValuePair<LanEthernetInterfaceConfigGetStatisticsResponse?, UPnPFault?>? lanEthernetInterfaceConfigGetStatisticsResponse;

    public LanEthernetInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "LANEthernetInterfaceConfig")
    {
    }

    public KeyValuePair<LanEthernetInterfaceConfigGetInfoResponse?, UPnPFault?>? LanEthernetInterfaceConfigGetInfoResponse
    {
        get => lanEthernetInterfaceConfigGetInfoResponse;
        private set => _ = SetProperty(ref lanEthernetInterfaceConfigGetInfoResponse, value);
    }

    public KeyValuePair<LanEthernetInterfaceConfigGetStatisticsResponse?, UPnPFault?>? LanEthernetInterfaceConfigGetStatisticsResponse
    {
        get => lanEthernetInterfaceConfigGetStatisticsResponse;
        private set => _ = SetProperty(ref lanEthernetInterfaceConfigGetStatisticsResponse, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(
            new[]
            {
                GetLanEthernetInterfaceConfigGetInfoAsync(),
                GetLanEthernetInterfaceConfigGetStatisticsAsync()
            },
            true);
    }

    private async Task GetLanEthernetInterfaceConfigGetInfoAsync()
        => LanEthernetInterfaceConfigGetInfoResponse = await ExecuteApiAsync(q => q.LanEthernetInterfaceConfigGetInfoAsync()).ConfigureAwait(true);

    private async Task GetLanEthernetInterfaceConfigGetStatisticsAsync()
        => LanEthernetInterfaceConfigGetStatisticsResponse = await ExecuteApiAsync(q => q.LanEthernetInterfaceConfigGetStatisticsAsync()).ConfigureAwait(true);
}
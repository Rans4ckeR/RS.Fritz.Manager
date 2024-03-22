namespace RS.Fritz.Manager.UI;

internal sealed class LanEthernetInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : FritzServiceViewModel(deviceLoginInfo, logger, "LANEthernetInterfaceConfig")
{
    private KeyValuePair<LanEthernetInterfaceConfigGetInfoResponse?, UPnPFault?>? lanEthernetInterfaceConfigGetInfoResponse;
    private KeyValuePair<LanEthernetInterfaceConfigGetStatisticsResponse?, UPnPFault?>? lanEthernetInterfaceConfigGetStatisticsResponse;

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
        => API.TaskExtensions.WhenAllSafe([GetLanEthernetInterfaceConfigGetInfoAsync(), GetLanEthernetInterfaceConfigGetStatisticsAsync()], true);

    private async Task GetLanEthernetInterfaceConfigGetInfoAsync()
        => LanEthernetInterfaceConfigGetInfoResponse = await ExecuteApiAsync(q => q.LanEthernetInterfaceConfigGetInfoAsync()).ConfigureAwait(true);

    private async Task GetLanEthernetInterfaceConfigGetStatisticsAsync()
        => LanEthernetInterfaceConfigGetStatisticsResponse = await ExecuteApiAsync(q => q.LanEthernetInterfaceConfigGetStatisticsAsync()).ConfigureAwait(true);
}
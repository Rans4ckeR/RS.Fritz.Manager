namespace RS.Fritz.Manager.UI;

internal sealed class LanEthernetInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<LanEthernetInterfaceConfigViewModel> logger)
    : FritzServiceViewModel(deviceLoginInfo, logger, "LANEthernetInterfaceConfig")
{
    public KeyValuePair<LanEthernetInterfaceConfigGetInfoResponse?, UPnPFault?>? LanEthernetInterfaceConfigGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<LanEthernetInterfaceConfigGetStatisticsResponse?, UPnPFault?>? LanEthernetInterfaceConfigGetStatisticsResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => Task.WhenAll(GetLanEthernetInterfaceConfigGetInfoAsync(), GetLanEthernetInterfaceConfigGetStatisticsAsync()).Evaluate(ConfigureAwaitOptions.ContinueOnCapturedContext);

    private async Task GetLanEthernetInterfaceConfigGetInfoAsync()
        => LanEthernetInterfaceConfigGetInfoResponse = await ExecuteApiAsync(static q => q.LanEthernetInterfaceConfigGetInfoAsync()).ConfigureAwait(true);

    private async Task GetLanEthernetInterfaceConfigGetStatisticsAsync()
        => LanEthernetInterfaceConfigGetStatisticsResponse = await ExecuteApiAsync(static q => q.LanEthernetInterfaceConfigGetStatisticsAsync()).ConfigureAwait(true);
}
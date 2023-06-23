namespace RS.Fritz.Manager.UI;

internal sealed class WanEthernetLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : FritzServiceViewModel(deviceLoginInfo, logger)
{
    private KeyValuePair<WanEthernetLinkConfigGetEthernetLinkStatusResponse?, UPnPFault?>? wanEthernetLinkConfigGetEthernetLinkStatusResponse;

    public KeyValuePair<WanEthernetLinkConfigGetEthernetLinkStatusResponse?, UPnPFault?>? WanEthernetLinkConfigGetEthernetLinkStatusResponse
    {
        get => wanEthernetLinkConfigGetEthernetLinkStatusResponse;
        private set => _ = SetProperty(ref wanEthernetLinkConfigGetEthernetLinkStatusResponse, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => WanEthernetLinkConfigGetEthernetLinkStatusResponse = await ExecuteApiAsync(q => q.WanEthernetLinkConfigGetEthernetLinkStatusAsync()).ConfigureAwait(true);
}
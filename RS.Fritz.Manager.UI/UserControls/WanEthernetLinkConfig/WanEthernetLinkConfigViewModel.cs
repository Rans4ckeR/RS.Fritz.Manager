namespace RS.Fritz.Manager.UI;

internal sealed class WanEthernetLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : FritzServiceViewModel(deviceLoginInfo, logger)
{
    public KeyValuePair<WanEthernetLinkConfigGetEthernetLinkStatusResponse?, UPnPFault?>? WanEthernetLinkConfigGetEthernetLinkStatusResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => WanEthernetLinkConfigGetEthernetLinkStatusResponse = await ExecuteApiAsync(static q => q.WanEthernetLinkConfigGetEthernetLinkStatusAsync()).ConfigureAwait(true);
}
namespace RS.Fritz.Manager.UI;

internal sealed class WanEthernetLinkConfigViewModel : FritzServiceViewModel
{
    private KeyValuePair<WanEthernetLinkConfigGetEthernetLinkStatusResponse?, UPnPFault?>? wanEthernetLinkConfigGetEthernetLinkStatusResponse;

    public WanEthernetLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public KeyValuePair<WanEthernetLinkConfigGetEthernetLinkStatusResponse?, UPnPFault?>? WanEthernetLinkConfigGetEthernetLinkStatusResponse
    {
        get => wanEthernetLinkConfigGetEthernetLinkStatusResponse;
        private set => _ = SetProperty(ref wanEthernetLinkConfigGetEthernetLinkStatusResponse, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => WanEthernetLinkConfigGetEthernetLinkStatusResponse = await ExecuteApiAsync(q => q.WanEthernetLinkConfigGetEthernetLinkStatusAsync());
}
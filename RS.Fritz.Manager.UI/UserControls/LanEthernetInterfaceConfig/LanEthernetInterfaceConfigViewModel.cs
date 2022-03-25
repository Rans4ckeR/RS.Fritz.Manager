namespace RS.Fritz.Manager.UI;

internal sealed class LanEthernetInterfaceConfigViewModel : FritzServiceViewModel
{
    private LanEthernetInterfaceConfigGetInfoResponse? lanEthernetInterfaceConfigGetInfoResponse;

    public LanEthernetInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public LanEthernetInterfaceConfigGetInfoResponse? LanEthernetInterfaceConfigGetInfoResponse
    {
        get => lanEthernetInterfaceConfigGetInfoResponse;
        private set { _ = SetProperty(ref lanEthernetInterfaceConfigGetInfoResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        LanEthernetInterfaceConfigGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.LanEthernetInterfaceConfigGetInfoAsync();
    }
}
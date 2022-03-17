namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanEthernetLinkConfigViewModel : FritzServiceViewModel
{
    private WanEthernetLinkConfigGetEthernetLinkStatusResponse? wanEthernetLinkConfigGetEthernetLinkStatusResponse;

    public WanEthernetLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public WanEthernetLinkConfigGetEthernetLinkStatusResponse? WanEthernetLinkConfigGetEthernetLinkStatusResponse
    {
        get => wanEthernetLinkConfigGetEthernetLinkStatusResponse;
        private set { _ = SetProperty(ref wanEthernetLinkConfigGetEthernetLinkStatusResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        WanEthernetLinkConfigGetEthernetLinkStatusResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanEthernetLinkConfigGetEthernetLinkStatusAsync();
    }
}
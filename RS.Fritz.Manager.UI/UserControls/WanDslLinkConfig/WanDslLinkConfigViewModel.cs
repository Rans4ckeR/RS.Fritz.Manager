namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanDslLinkConfigViewModel : FritzServiceViewModel
{
    private WanDslLinkConfigGetInfoResponse? wanDslLinkConfigGetInfoResponse;

    public WanDslLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public WanDslLinkConfigGetInfoResponse? WanDslLinkConfigGetInfoResponse
    {
        get => wanDslLinkConfigGetInfoResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetInfoResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        WanDslLinkConfigGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslLinkConfigGetInfoAsync();
    }
}
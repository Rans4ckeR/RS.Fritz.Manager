namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanDslLinkConfigViewModel : FritzServiceViewModel
{
    private WanDslLinkConfigGetInfoResponse? wanDslLinkConfigGetInfoResponse;
    private WanDslLinkConfigGetDslLinkInfoResponse? wanDslLinkConfigGetDslLinkInfoResponse;

    public WanDslLinkConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public WanDslLinkConfigGetInfoResponse? WanDslLinkConfigGetInfoResponse
    {
        get => wanDslLinkConfigGetInfoResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetInfoResponse, value); }
    }

    public WanDslLinkConfigGetDslLinkInfoResponse? WanDslLinkConfigGetDslLinkInfoResponse
    {
        get => wanDslLinkConfigGetDslLinkInfoResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetDslLinkInfoResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
          {
                GetWanDslLinkConfigGetInfoAsync(),
                GetWanDslLinkConfigGetDslLinkInfoAsync()
          });
    }

    private async Task GetWanDslLinkConfigGetInfoAsync()
    {
        WanDslLinkConfigGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslLinkConfigGetInfoAsync();
    }

    private async Task GetWanDslLinkConfigGetDslLinkInfoAsync()
    {
        WanDslLinkConfigGetDslLinkInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslLinkConfigGetDslLinkInfoAsync();
    }
}
namespace RS.Fritz.Manager.UI;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanDslLinkConfigViewModel : FritzServiceViewModel
{
    private WanDslLinkConfigGetInfoResponse? wanDslLinkConfigGetInfoResponse;
    private WanDslLinkConfigGetDslLinkInfoResponse? wanDslLinkConfigGetDslLinkInfoResponse;
    private WanDslLinkConfigGetDestinationAddressResponse? wanDslLinkConfigGetDestinationAddressResponse;
    private WanDslLinkConfigGetAtmEncapsulationResponse? wanDslLinkConfigGetAtmEncapsulationResponse;
    private WanDslLinkConfigGetAutoConfigResponse? wanDslLinkConfigGetAutoConfigResponse;
    private WanDslLinkConfigGetStatisticsResponse? wanDslLinkConfigGetStatisticsResponse;

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

    public WanDslLinkConfigGetDestinationAddressResponse? WanDslLinkConfigGetDestinationAddressResponse
    {
        get => wanDslLinkConfigGetDestinationAddressResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetDestinationAddressResponse, value); }
    }

    public WanDslLinkConfigGetAtmEncapsulationResponse? WanDslLinkConfigGetAtmEncapsulationResponse
    {
        get => wanDslLinkConfigGetAtmEncapsulationResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetAtmEncapsulationResponse, value); }
    }

    public WanDslLinkConfigGetAutoConfigResponse? WanDslLinkConfigGetAutoConfigResponse
    {
        get => wanDslLinkConfigGetAutoConfigResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetAutoConfigResponse, value); }
    }

    public WanDslLinkConfigGetStatisticsResponse? WanDslLinkConfigGetStatisticsResponse
    {
        get => wanDslLinkConfigGetStatisticsResponse;
        private set { _ = SetProperty(ref wanDslLinkConfigGetStatisticsResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken = default)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
          {
                GetWanDslLinkConfigGetInfoAsync(),
                GetWanDslLinkConfigGetDslLinkInfoAsync(),
                GetWanDslLinkConfigGetDestinationAddressAsync(),
                GetWanDslLinkConfigGetAtmEncapsulationAsync(),
                GetWanDslLinkConfigGetAutoConfigAsync(),
                GetWanDslLinkConfigGetStatisticsAsync()
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

    private async Task GetWanDslLinkConfigGetDestinationAddressAsync()
    {
        WanDslLinkConfigGetDestinationAddressResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslLinkConfigGetDestinationAddressAsync();
    }

    private async Task GetWanDslLinkConfigGetAtmEncapsulationAsync()
    {
        WanDslLinkConfigGetAtmEncapsulationResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslLinkConfigGetAtmEncapsulationAsync();
    }

    private async Task GetWanDslLinkConfigGetAutoConfigAsync()
    {
        WanDslLinkConfigGetAutoConfigResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslLinkConfigGetAutoConfigAsync();
    }

    private async Task GetWanDslLinkConfigGetStatisticsAsync()
    {
        WanDslLinkConfigGetStatisticsResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslLinkConfigGetStatisticsAsync();
    }
}
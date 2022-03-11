namespace RS.Fritz.Manager.UI;

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanCommonInterfaceConfigViewModel : FritzServiceViewModel
{
    private WanCommonInterfaceConfigGetCommonLinkPropertiesResponse? wanCommonInterfaceConfigGetCommonLinkPropertiesResponse;
    private WanCommonInterfaceConfigGetTotalBytesReceivedResponse? wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
    private WanCommonInterfaceConfigGetTotalBytesSentResponse? wanCommonInterfaceConfigGetTotalBytesSentResponse;
    private WanCommonInterfaceConfigGetTotalPacketsReceivedResponse? wanCommonInterfaceConfigGetTotalPacketsReceivedResponse;
    private WanCommonInterfaceConfigGetTotalPacketsSentResponse? wanCommonInterfaceConfigGetTotalPacketsSentResponse;

    public WanCommonInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public WanCommonInterfaceConfigGetTotalBytesReceivedResponse? WanCommonInterfaceConfigGetTotalBytesReceivedResponse
    {
        get => wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesReceivedResponse, value); }
    }

    public WanCommonInterfaceConfigGetTotalBytesSentResponse? WanCommonInterfaceConfigGetTotalBytesSentResponse
    {
        get => wanCommonInterfaceConfigGetTotalBytesSentResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesSentResponse, value); }
    }

    public WanCommonInterfaceConfigGetTotalPacketsReceivedResponse? WanCommonInterfaceConfigGetTotalPacketsReceivedResponse
    {
        get => wanCommonInterfaceConfigGetTotalPacketsReceivedResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalPacketsReceivedResponse, value); }
    }

    public WanCommonInterfaceConfigGetTotalPacketsSentResponse? WanCommonInterfaceConfigGetTotalPacketsSentResponse
    {
        get => wanCommonInterfaceConfigGetTotalPacketsSentResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalPacketsSentResponse, value); }
    }

    public WanCommonInterfaceConfigGetCommonLinkPropertiesResponse? WanCommonInterfaceConfigGetCommonLinkPropertiesResponse
    {
        get => wanCommonInterfaceConfigGetCommonLinkPropertiesResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetCommonLinkPropertiesResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync()
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
               GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync(),
               GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync(),
               GetWanCommonInterfaceConfigGetTotalBytesSentAsync(),
               GetWanCommonInterfaceConfigGetTotalPacketsReceivedAsync(),
               GetWanCommonInterfaceConfigGetTotalPacketsSentAsync()
            });
    }

    private async Task GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync()
    {
        WanCommonInterfaceConfigGetCommonLinkPropertiesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync(d));
    }

    private async Task GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync()
    {
        WanCommonInterfaceConfigGetTotalBytesReceivedResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalBytesReceivedAsync(d));
    }

    private async Task GetWanCommonInterfaceConfigGetTotalBytesSentAsync()
    {
        WanCommonInterfaceConfigGetTotalBytesSentResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalBytesSentAsync(d));
    }

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsReceivedAsync()
    {
        WanCommonInterfaceConfigGetTotalPacketsReceivedResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(d));
    }

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsSentAsync()
    {
        WanCommonInterfaceConfigGetTotalPacketsSentResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalPacketsSentAsync(d));
    }
}
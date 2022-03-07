namespace RS.Fritz.Manager.UI
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.API;

    internal sealed class WanCommonInterfaceConfigViewModel : FritzServiceViewModel
    {
        private WanCommonInterfaceConfigGetCommonLinkPropertiesResponse? wanCommonInterfaceConfigGetCommonLinkPropertiesResponse;
        private WanCommonInterfaceConfigGetTotalBytesReceivedResponse? wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
        private WanCommonInterfaceConfigGetTotalBytesSentResponse? wanCommonInterfaceConfigGetTotalBytesSentResponse;

        public WanCommonInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
            : base(deviceLoginInfo, logger)
        {
        }

        public WanCommonInterfaceConfigGetTotalBytesReceivedResponse? WanCommonInterfaceConfigGetTotalBytesReceivedResponse
        {
            get => wanCommonInterfaceConfigGetTotalBytesReceivedResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesReceivedResponse, value); }
        }

        public WanCommonInterfaceConfigGetTotalBytesSentResponse? WanCommonInterfaceConfigGetTotalBytesSentResponse
        {
            get => wanCommonInterfaceConfigGetTotalBytesSentResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesSentResponse, value); }
        }

        public WanCommonInterfaceConfigGetCommonLinkPropertiesResponse? WanCommonInterfaceConfigGetCommonLinkPropertiesResponse
        {
            get => wanCommonInterfaceConfigGetCommonLinkPropertiesResponse; set { _ = SetProperty(ref wanCommonInterfaceConfigGetCommonLinkPropertiesResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            await API.TaskExtensions.WhenAllSafe(new[]
                {
                   GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync(),
                   GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync(),
                   GetWanCommonInterfaceConfigGetTotalBytesSentAsync()
                });
        }

        private async Task GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync()
        {
            WanCommonInterfaceConfigGetCommonLinkPropertiesResponse = await DeviceLoginInfo.InternetGatewayDevice!.InternetGatewayDevice.ExecuteAsync((h, d) => h.GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync(d));
        }

        private async Task GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync()
        {
            WanCommonInterfaceConfigGetTotalBytesReceivedResponse = await DeviceLoginInfo.InternetGatewayDevice!.InternetGatewayDevice.ExecuteAsync((h, d) => h.GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync(d));
        }

        private async Task GetWanCommonInterfaceConfigGetTotalBytesSentAsync()
        {
            WanCommonInterfaceConfigGetTotalBytesSentResponse = await DeviceLoginInfo.InternetGatewayDevice!.InternetGatewayDevice.ExecuteAsync((h, d) => h.GetWanCommonInterfaceConfigGetTotalBytesSentAsync(d));
        }
    }
}
namespace RS.Fritz.Manager.UI
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.API;

    internal sealed class WanIpConnectionViewModel : FritzServiceViewModel
    {
        private WanIpConnectionGetInfoResponse? wanIpConnectionGetInfoResponse;

        public WanIpConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
            : base(deviceLoginInfo, logger)
        {
        }

        public WanIpConnectionGetInfoResponse? WanIpConnectionGetInfoResponse
        {
            get => wanIpConnectionGetInfoResponse; set { _ = SetProperty(ref wanIpConnectionGetInfoResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            WanIpConnectionGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.InternetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetInfoAsync(d));
        }
    }
}
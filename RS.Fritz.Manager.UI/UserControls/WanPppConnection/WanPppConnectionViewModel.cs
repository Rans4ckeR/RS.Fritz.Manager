namespace RS.Fritz.Manager.UI
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.API;

    internal sealed class WanPppConnectionViewModel : FritzServiceViewModel
    {
        private WanPppConnectionGetInfoResponse? wanPppConnectionGetInfoResponse;

        public WanPppConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
            : base(deviceLoginInfo, logger)
        {
        }

        public WanPppConnectionGetInfoResponse? WanPppConnectionGetInfoResponse
        {
            get => wanPppConnectionGetInfoResponse; set { _ = SetProperty(ref wanPppConnectionGetInfoResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            WanPppConnectionGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanPppConnectionGetInfoAsync(d));
        }
    }
}
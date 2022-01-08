namespace RS.Fritz.Manager.UI
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class WanPppConnectionViewModel : FritzServiceViewModel
    {
        private WanPppConnectionGetInfoResponse? wanPppConnectionGetInfoResponse;
        
        public WanPppConnectionViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(deviceLoginInfo, logger, fritzServiceOperationHandler)
        {
        }

        public WanPppConnectionGetInfoResponse? WanPppConnectionGetInfoResponse
        {
            get => wanPppConnectionGetInfoResponse; set { _ = SetProperty(ref wanPppConnectionGetInfoResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            WanPppConnectionGetInfoResponse = await FritzServiceOperationHandler.WanPppConnectionGetInfoAsync();
        }
    }
}
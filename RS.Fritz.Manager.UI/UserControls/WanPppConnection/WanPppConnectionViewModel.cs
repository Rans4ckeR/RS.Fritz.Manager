namespace RS.Fritz.Manager.UI
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class WanPppConnectionViewModel : FritzServiceViewModel
    {
        private readonly IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory;

        private WanPppConnectionGetInfoResponse? wanPppConnectionGetInfoResponse;

        public WanPppConnectionViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory)
            : base(logger, deviceLoginInfo, serviceOperationHandler)
        {
            this.fritzWanPppConnectionServiceClientFactory = fritzWanPppConnectionServiceClientFactory;
        }

        public WanPppConnectionGetInfoResponse? WanPppConnectionGetInfoResponse
        {
            get => wanPppConnectionGetInfoResponse; set { _ = SetProperty(ref wanPppConnectionGetInfoResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync(NetworkCredential networkCredential)
        {
            WanPppConnectionGetInfoResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzWanPppConnectionServiceClient(DeviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetInfoAsync(new WanPppConnectionGetInfoRequest()));
        }

        private IFritzWanPppConnectionService GetFritzWanPppConnectionServiceClient(ushort port, NetworkCredential networkCredential)
        {
            return fritzWanPppConnectionServiceClientFactory.Build((q, r, t) => new FritzWanPppConnectionService(q, r, t!), DeviceLoginInfo.Device!.PreferredLocation, true, FritzWanPppConnectionService.ControlUrl, port, networkCredential);
        }
    }
}
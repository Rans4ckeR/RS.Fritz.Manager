namespace RS.Fritz.Manager.UI
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class Layer3ForwardingViewModel : FritzServiceViewModel
    {
        private readonly IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory;

        private Layer3ForwardingGetDefaultConnectionServiceResponse? layer3ForwardingGetDefaultConnectionServiceResponse;

        public Layer3ForwardingViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory)
            : base(logger, deviceLoginInfo, serviceOperationHandler)
        {
            this.fritzLayer3ForwardingServiceClientFactory = fritzLayer3ForwardingServiceClientFactory;
        }

        public Layer3ForwardingGetDefaultConnectionServiceResponse? Layer3ForwardingGetDefaultConnectionServiceResponse
        {
            get => layer3ForwardingGetDefaultConnectionServiceResponse; set { _ = SetProperty(ref layer3ForwardingGetDefaultConnectionServiceResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync(NetworkCredential networkCredential)
        {
            Layer3ForwardingGetDefaultConnectionServiceResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzLayer3ForwardingServiceClient(DeviceLoginInfo.Device!.SecurityPort!.Value, networkCredential), q => q.GetDefaultConnectionServiceAsync(new Layer3ForwardingGetDefaultConnectionServiceRequest()));
        }

        private IFritzLayer3ForwardingService GetFritzLayer3ForwardingServiceClient(ushort port, NetworkCredential networkCredential)
        {
            return fritzLayer3ForwardingServiceClientFactory.Build((q, r, t) => new FritzLayer3ForwardingService(q, r, t!), DeviceLoginInfo.Device!.PreferredLocation, true, FritzLayer3ForwardingService.ControlUrl, port, networkCredential);
        }
    }
}
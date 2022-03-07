namespace RS.Fritz.Manager.UI
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.API;

    internal sealed class Layer3ForwardingViewModel : FritzServiceViewModel
    {
        private Layer3ForwardingGetDefaultConnectionServiceResponse? layer3ForwardingGetDefaultConnectionServiceResponse;

        public Layer3ForwardingViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
            : base(deviceLoginInfo, logger)
        {
        }

        public Layer3ForwardingGetDefaultConnectionServiceResponse? Layer3ForwardingGetDefaultConnectionServiceResponse
        {
            get => layer3ForwardingGetDefaultConnectionServiceResponse; set { _ = SetProperty(ref layer3ForwardingGetDefaultConnectionServiceResponse, value); }
        }

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            Layer3ForwardingGetDefaultConnectionServiceResponse = await DeviceLoginInfo.InternetGatewayDevice!.InternetGatewayDevice.ExecuteAsync((h, d) => h.Layer3ForwardingGetDefaultConnectionServiceAsync(d));
        }
    }
}
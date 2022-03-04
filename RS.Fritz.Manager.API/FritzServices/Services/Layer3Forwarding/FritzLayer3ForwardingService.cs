namespace RS.Fritz.Manager.API
{
    using System.Net;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public sealed class FritzLayer3ForwardingService : FritzServiceClient<IFritzLayer3ForwardingService>, IFritzLayer3ForwardingService
    {
        public const string ControlUrl = "/upnp/control/layer3forwarding";

        public FritzLayer3ForwardingService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
            : base(endpointConfiguration, remoteAddress, networkCredential)
        {
        }

        public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> GetDefaultConnectionServiceAsync(Layer3ForwardingGetDefaultConnectionServiceRequest layer3ForwardingGetDefaultConnectionServiceRequest)
        {
            return Channel.GetDefaultConnectionServiceAsync(layer3ForwardingGetDefaultConnectionServiceRequest);
        }
    }
}
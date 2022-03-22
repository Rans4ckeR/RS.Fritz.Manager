namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzLayer3ForwardingService : FritzServiceClient<IFritzLayer3ForwardingService>, IFritzLayer3ForwardingService
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

    public Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> GetForwardNumberOfEntriesAsync(Layer3ForwardingGetForwardNumberOfEntriesRequest layer3ForwardingGetForwardNumberOfEntriesRequest)
    {
        return Channel.GetForwardNumberOfEntriesAsync(layer3ForwardingGetForwardNumberOfEntriesRequest);
    }

    public Task<Layer3ForwardingGetGenericForwardingEntryResponse> GetGenericForwardingEntryAsync(Layer3ForwardingGetGenericForwardingEntryRequest layer3ForwardingGetGenericForwardingEntryRequest)
    {
        return Channel.GetGenericForwardingEntryAsync(layer3ForwardingGetGenericForwardingEntryRequest);
    }
}
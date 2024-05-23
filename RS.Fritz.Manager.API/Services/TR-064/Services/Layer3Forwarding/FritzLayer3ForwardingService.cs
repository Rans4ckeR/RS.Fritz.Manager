namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzLayer3ForwardingService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzLayer3ForwardingService>(binding, remoteAddress), IFritzLayer3ForwardingService
{
    public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> GetDefaultConnectionServiceAsync(Layer3ForwardingGetDefaultConnectionServiceRequest layer3ForwardingGetDefaultConnectionServiceRequest)
        => Channel.GetDefaultConnectionServiceAsync(layer3ForwardingGetDefaultConnectionServiceRequest);

    public Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> GetForwardNumberOfEntriesAsync(Layer3ForwardingGetForwardNumberOfEntriesRequest layer3ForwardingGetForwardNumberOfEntriesRequest)
        => Channel.GetForwardNumberOfEntriesAsync(layer3ForwardingGetForwardNumberOfEntriesRequest);

    public Task<Layer3ForwardingGetGenericForwardingEntryResponse> GetGenericForwardingEntryAsync(Layer3ForwardingGetGenericForwardingEntryRequest layer3ForwardingGetGenericForwardingEntryRequest)
        => Channel.GetGenericForwardingEntryAsync(layer3ForwardingGetGenericForwardingEntryRequest);
}
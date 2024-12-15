﻿using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzLayer3ForwardingService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzLayer3ForwardingService>(endpointConfiguration, remoteAddress, networkCredential), IFritzLayer3ForwardingService
{
    public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> GetDefaultConnectionServiceAsync(Layer3ForwardingGetDefaultConnectionServiceRequest layer3ForwardingGetDefaultConnectionServiceRequest)
        => Channel.GetDefaultConnectionServiceAsync(layer3ForwardingGetDefaultConnectionServiceRequest);

    public Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> GetForwardNumberOfEntriesAsync(Layer3ForwardingGetForwardNumberOfEntriesRequest layer3ForwardingGetForwardNumberOfEntriesRequest)
        => Channel.GetForwardNumberOfEntriesAsync(layer3ForwardingGetForwardNumberOfEntriesRequest);

    public Task<Layer3ForwardingGetGenericForwardingEntryResponse> GetGenericForwardingEntryAsync(Layer3ForwardingGetGenericForwardingEntryRequest layer3ForwardingGetGenericForwardingEntryRequest)
        => Channel.GetGenericForwardingEntryAsync(layer3ForwardingGetGenericForwardingEntryRequest);
}
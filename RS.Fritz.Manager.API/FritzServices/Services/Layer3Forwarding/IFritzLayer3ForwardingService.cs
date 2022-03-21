namespace RS.Fritz.Manager.API;

using System.ServiceModel;
using System.Threading.Tasks;

[ServiceContract(Namespace = "urn:dslforum-org:service:Layer3Forwarding:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLayer3ForwardingService
{
    [OperationContract(Action = "urn:dslforum-org:service:Layer3Forwarding:1#GetDefaultConnectionService")]
    public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> GetDefaultConnectionServiceAsync(Layer3ForwardingGetDefaultConnectionServiceRequest layer3ForwardingGetDefaultConnectionServiceRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Layer3Forwarding:1#GetForwardNumberOfEntries")]
    public Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> GetForwardNumberOfEntriesAsync(Layer3ForwardingGetForwardNumberOfEntriesRequest layer3ForwardingGetForwardNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Layer3Forwarding:1#GetGenericForwardingEntry")]
    public Task<Layer3ForwardingGetGenericForwardingEntryResponse> GetGenericForwardingEntryAsync(Layer3ForwardingGetGenericForwardingEntryRequest layer3ForwardingGetGenericForwardingEntryRequest);
}
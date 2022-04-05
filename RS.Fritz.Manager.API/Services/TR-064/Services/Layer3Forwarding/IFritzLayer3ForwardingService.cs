namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:Layer3Forwarding:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLayer3ForwardingService
{
    [OperationContract(Action = "urn:dslforum-org:service:Layer3Forwarding:1#GetDefaultConnectionService")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<Layer3ForwardingGetDefaultConnectionServiceResponse> GetDefaultConnectionServiceAsync(Layer3ForwardingGetDefaultConnectionServiceRequest layer3ForwardingGetDefaultConnectionServiceRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Layer3Forwarding:1#GetForwardNumberOfEntries")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> GetForwardNumberOfEntriesAsync(Layer3ForwardingGetForwardNumberOfEntriesRequest layer3ForwardingGetForwardNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Layer3Forwarding:1#GetGenericForwardingEntry")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<Layer3ForwardingGetGenericForwardingEntryResponse> GetGenericForwardingEntryAsync(Layer3ForwardingGetGenericForwardingEntryRequest layer3ForwardingGetGenericForwardingEntryRequest);
}
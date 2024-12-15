namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:Layer3Forwarding:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLayer3ForwardingService : IFritzService
{
    static string IFritzService.ControlUrl => "/upnp/control/layer3forwarding";

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Layer3Forwarding:1#GetDefaultConnectionService")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<Layer3ForwardingGetDefaultConnectionServiceResponse> GetDefaultConnectionServiceAsync(Layer3ForwardingGetDefaultConnectionServiceRequest layer3ForwardingGetDefaultConnectionServiceRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Layer3Forwarding:1#GetForwardNumberOfEntries")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> GetForwardNumberOfEntriesAsync(Layer3ForwardingGetForwardNumberOfEntriesRequest layer3ForwardingGetForwardNumberOfEntriesRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Layer3Forwarding:1#GetGenericForwardingEntry")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<Layer3ForwardingGetGenericForwardingEntryResponse> GetGenericForwardingEntryAsync(Layer3ForwardingGetGenericForwardingEntryRequest layer3ForwardingGetGenericForwardingEntryRequest);
}
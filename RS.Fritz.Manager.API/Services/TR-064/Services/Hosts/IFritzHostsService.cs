namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:Hosts:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzHostsService
{
    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#GetHostNumberOfEntries")]
    [FaultContract(typeof(UPnPFault))]
    public Task<HostsGetHostNumberOfEntriesResponse> GetHostNumberOfEntriesAsync(HostsGetHostNumberOfEntriesRequest hostsGetHostNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetHostListPath")]
    [FaultContract(typeof(UPnPFault))]
    public Task<HostsGetHostListPathResponse> GetHostListPathAsync(HostsGetHostListPathRequest hostsGetHostListPathRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#GetGenericHostEntry")]
    [FaultContract(typeof(UPnPFault))]
    public Task<HostsGetGenericHostEntryResponse> GetGenericHostEntryAsync(HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetChangeCounter")]
    [FaultContract(typeof(UPnPFault))]
    public Task<HostsGetChangeCounterResponse> GetChangeCounterAsync(HostsGetChangeCounterRequest hostsGetChangeCounterRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetMeshListPath")]
    [FaultContract(typeof(UPnPFault))]
    public Task<HostsGetMeshListPathResponse> GetMeshListPathAsync(HostsGetMeshListPathRequest hostsGetMeshListPathRequest);
}
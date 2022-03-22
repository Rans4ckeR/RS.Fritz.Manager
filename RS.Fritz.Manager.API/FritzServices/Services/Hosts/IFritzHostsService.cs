namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:Hosts:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzHostsService
{
    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#GetHostNumberOfEntries")]
    public Task<HostsGetHostNumberOfEntriesResponse> GetHostNumberOfEntriesAsync(HostsGetHostNumberOfEntriesRequest hostsGetHostNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetHostListPath")]
    public Task<HostsGetHostListPathResponse> GetHostListPathAsync(HostsGetHostListPathRequest hostsGetHostListPathRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#GetGenericHostEntry")]
    public Task<HostsGetGenericHostEntryResponse> GetGenericHostEntryAsync(HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetChangeCounter")]
    public Task<HostsGetChangeCounterResponse> GetChangeCounterAsync(HostsGetChangeCounterRequest hostsGetChangeCounterRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetMeshListPath")]
    public Task<HostsGetMeshListPathResponse> GetMeshListPathAsync(HostsGetMeshListPathRequest hostsGetMeshListPathRequest);
}
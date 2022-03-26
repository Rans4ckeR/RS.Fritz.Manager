namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:Hosts:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzHostsService
{
    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#GetHostNumberOfEntries")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<HostsGetHostNumberOfEntriesResponse> GetHostNumberOfEntriesAsync(HostsGetHostNumberOfEntriesRequest hostsGetHostNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetHostListPath")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<HostsGetHostListPathResponse> GetHostListPathAsync(HostsGetHostListPathRequest hostsGetHostListPathRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#GetGenericHostEntry")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<HostsGetGenericHostEntryResponse> GetGenericHostEntryAsync(HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetChangeCounter")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<HostsGetChangeCounterResponse> GetChangeCounterAsync(HostsGetChangeCounterRequest hostsGetChangeCounterRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetMeshListPath")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<HostsGetMeshListPathResponse> GetMeshListPathAsync(HostsGetMeshListPathRequest hostsGetMeshListPathRequest);
}
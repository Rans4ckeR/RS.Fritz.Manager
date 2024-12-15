namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:Hosts:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzHostsService : IFritzService
{
    static string IFritzService.ControlUrl => "/upnp/control/hosts";

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Hosts:1#GetHostNumberOfEntries")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<HostsGetHostNumberOfEntriesResponse> GetHostNumberOfEntriesAsync(HostsGetHostNumberOfEntriesRequest hostsGetHostNumberOfEntriesRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Hosts:1#X_AVM-DE_HostsCheckUpdate")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<HostsHostsCheckUpdateResponse> HostsCheckUpdateAsync(HostsHostsCheckUpdateRequest hostsHostsCheckUpdateRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Hosts:1#X_AVM-DE_GetHostListPath")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<HostsGetHostListPathResponse> GetHostListPathAsync(HostsGetHostListPathRequest hostsGetHostListPathRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Hosts:1#GetGenericHostEntry")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<HostsGetGenericHostEntryResponse> GetGenericHostEntryAsync(HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Hosts:1#X_AVM-DE_GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<HostsGetInfoResponse> GetInfoAsync(HostsGetInfoRequest hostsGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Hosts:1#X_AVM-DE_GetChangeCounter")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<HostsGetChangeCounterResponse> GetChangeCounterAsync(HostsGetChangeCounterRequest hostsGetChangeCounterRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Hosts:1#X_AVM-DE_GetMeshListPath")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<HostsGetMeshListPathResponse> GetMeshListPathAsync(HostsGetMeshListPathRequest hostsGetMeshListPathRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Hosts:1#X_AVM-DE_GetFriendlyName")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<HostsGetFriendlyNameResponse> GetFriendlyNameAsync(HostsGetFriendlyNameRequest hostsGetFriendlyNameRequest);
}
﻿namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:Hosts:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzHostsService : IAsyncDisposable
{
    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#GetHostNumberOfEntries")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<HostsGetHostNumberOfEntriesResponse> GetHostNumberOfEntriesAsync(HostsGetHostNumberOfEntriesRequest hostsGetHostNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_HostsCheckUpdate")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<HostsHostsCheckUpdateResponse> HostsCheckUpdateAsync(HostsHostsCheckUpdateRequest hostsHostsCheckUpdateRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetHostListPath")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<HostsGetHostListPathResponse> GetHostListPathAsync(HostsGetHostListPathRequest hostsGetHostListPathRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#GetGenericHostEntry")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<HostsGetGenericHostEntryResponse> GetGenericHostEntryAsync(HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<HostsGetInfoResponse> GetInfoAsync(HostsGetInfoRequest hostsGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetChangeCounter")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<HostsGetChangeCounterResponse> GetChangeCounterAsync(HostsGetChangeCounterRequest hostsGetChangeCounterRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetMeshListPath")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<HostsGetMeshListPathResponse> GetMeshListPathAsync(HostsGetMeshListPathRequest hostsGetMeshListPathRequest);

    [OperationContract(Action = "urn:dslforum-org:service:Hosts:1#X_AVM-DE_GetFriendlyName")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<HostsGetFriendlyNameResponse> GetFriendlyNameAsync(HostsGetFriendlyNameRequest hostsGetFriendlyNameRequest);
}
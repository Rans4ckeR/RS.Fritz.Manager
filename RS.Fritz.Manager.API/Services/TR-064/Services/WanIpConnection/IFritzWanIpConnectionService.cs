namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANIPConnection:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanIpConnectionService : IAsyncDisposable
{
    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanIpConnectionGetInfoResponse> GetInfoAsync(WanConnectionGetInfoRequest wanConnectionGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetConnectionTypeInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanConnectionGetConnectionTypeInfoRequest wanConnectionGetConnectionTypeInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetStatusInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanConnectionGetStatusInfoRequest wanConnectionGetStatusInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetNATRSIPStatus")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanConnectionGetNatRsipStatusRequest wanConnectionGetNatRsipStatusRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#X_GetDNSServers")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanConnectionGetDnsServersResponse> GetDnsServersAsync(WanConnectionGetDnsServersRequest wanConnectionGetDnsServersRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetPortMappingNumberOfEntries")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanConnectionGetPortMappingNumberOfEntriesRequest wanConnectionGetPortMappingNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetExternalIPAddress")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanConnectionGetExternalIpAddressRequest wanConnectionGetExternalIpAddressRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetGenericPortMappingEntry")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WanConnectionGetGenericPortMappingEntryResponse> GetGenericPortMappingEntryAsync(WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest);
}
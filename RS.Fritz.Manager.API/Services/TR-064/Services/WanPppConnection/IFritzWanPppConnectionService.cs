namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanPppConnectionService : IFritzService
{
    static string IFritzService.ControlUrl => "/upnp/control/wanpppconn1";

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanPppConnectionGetInfoResponse> GetInfoAsync(WanConnectionGetInfoRequest wanConnectionGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#GetConnectionTypeInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanConnectionGetConnectionTypeInfoRequest wanConnectionGetConnectionTypeInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#GetStatusInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanConnectionGetStatusInfoRequest wanConnectionGetStatusInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#GetLinkLayerMaxBitRates")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> GetLinkLayerMaxBitRatesAsync(WanPppConnectionGetLinkLayerMaxBitRatesRequest wanPppConnectionGetLinkLayerMaxBitRatesRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#GetUserName")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanPppConnectionGetUserNameResponse> GetUserNameAsync(WanPppConnectionGetUserNameRequest wanPppConnectionGetUserNameRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#GetNATRSIPStatus")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanConnectionGetNatRsipStatusRequest wanConnectionGetNatRsipStatusRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#X_GetDNSServers")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanConnectionGetDnsServersResponse> GetDnsServersAsync(WanConnectionGetDnsServersRequest wanConnectionGetDnsServersRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#GetPortMappingNumberOfEntries")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanConnectionGetPortMappingNumberOfEntriesRequest wanConnectionGetPortMappingNumberOfEntriesRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#GetExternalIPAddress")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanConnectionGetExternalIpAddressRequest wanConnectionGetExternalIpAddressRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#X_AVM-DE_GetAutoDisconnectTimeSpan")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> GetAutoDisconnectTimeSpanAsync(WanPppConnectionGetAutoDisconnectTimeSpanRequest wanPppConnectionGetAutoDisconnectTimeSpanRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WANPPPConnection:1#GetGenericPortMappingEntry")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WanConnectionGetGenericPortMappingEntryResponse> GetGenericPortMappingEntryAsync(WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest);
}
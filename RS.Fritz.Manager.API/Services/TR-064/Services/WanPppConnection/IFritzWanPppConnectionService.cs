namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANPPPConnection:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanPppConnectionService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetInfo")]
    public Task<WanPppConnectionGetInfoResponse> GetInfoAsync(WanConnectionGetInfoRequest wanConnectionGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetConnectionTypeInfo")]
    public Task<WanConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanConnectionGetConnectionTypeInfoRequest wanConnectionGetConnectionTypeInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetStatusInfo")]
    public Task<WanConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanConnectionGetStatusInfoRequest wanConnectionGetStatusInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetLinkLayerMaxBitRates")]
    public Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> GetLinkLayerMaxBitRatesAsync(WanPppConnectionGetLinkLayerMaxBitRatesRequest wanPppConnectionGetLinkLayerMaxBitRatesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetUserName")]
    public Task<WanPppConnectionGetUserNameResponse> GetUserNameAsync(WanPppConnectionGetUserNameRequest wanPppConnectionGetUserNameRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetNATRSIPStatus")]
    public Task<WanConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanConnectionGetNatRsipStatusRequest wanConnectionGetNatRsipStatusRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#X_GetDNSServers")]
    public Task<WanConnectionGetDnsServersResponse> GetDnsServersAsync(WanConnectionGetDnsServersRequest wanConnectionGetDnsServersRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetPortMappingNumberOfEntries")]
    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanConnectionGetPortMappingNumberOfEntriesRequest wanConnectionGetPortMappingNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetExternalIPAddress")]
    public Task<WanConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanConnectionGetExternalIpAddressRequest wanConnectionGetExternalIpAddressRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#X_AVM-DE_GetAutoDisconnectTimeSpan")]
    public Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> GetAutoDisconnectTimeSpanAsync(WanPppConnectionGetAutoDisconnectTimeSpanRequest wanPppConnectionGetAutoDisconnectTimeSpanRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetGenericPortMappingEntry")]
    public Task<WanConnectionGetGenericPortMappingEntryResponse> GetGenericPortMappingEntryAsync(WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest);
}
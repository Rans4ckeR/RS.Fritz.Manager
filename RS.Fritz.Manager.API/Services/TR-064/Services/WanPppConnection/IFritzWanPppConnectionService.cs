﻿namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANPPPConnection:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanPppConnectionService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanPppConnectionGetInfoResponse> GetInfoAsync(WanConnectionGetInfoRequest wanConnectionGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetConnectionTypeInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanConnectionGetConnectionTypeInfoRequest wanConnectionGetConnectionTypeInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetStatusInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanConnectionGetStatusInfoRequest wanConnectionGetStatusInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetLinkLayerMaxBitRates")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> GetLinkLayerMaxBitRatesAsync(WanPppConnectionGetLinkLayerMaxBitRatesRequest wanPppConnectionGetLinkLayerMaxBitRatesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetUserName")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanPppConnectionGetUserNameResponse> GetUserNameAsync(WanPppConnectionGetUserNameRequest wanPppConnectionGetUserNameRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetNATRSIPStatus")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanConnectionGetNatRsipStatusRequest wanConnectionGetNatRsipStatusRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#X_GetDNSServers")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanConnectionGetDnsServersResponse> GetDnsServersAsync(WanConnectionGetDnsServersRequest wanConnectionGetDnsServersRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetPortMappingNumberOfEntries")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanConnectionGetPortMappingNumberOfEntriesRequest wanConnectionGetPortMappingNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetExternalIPAddress")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanConnectionGetExternalIpAddressRequest wanConnectionGetExternalIpAddressRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#X_AVM-DE_GetAutoDisconnectTimeSpan")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> GetAutoDisconnectTimeSpanAsync(WanPppConnectionGetAutoDisconnectTimeSpanRequest wanPppConnectionGetAutoDisconnectTimeSpanRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetGenericPortMappingEntry")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WanConnectionGetGenericPortMappingEntryResponse> GetGenericPortMappingEntryAsync(WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest);
}
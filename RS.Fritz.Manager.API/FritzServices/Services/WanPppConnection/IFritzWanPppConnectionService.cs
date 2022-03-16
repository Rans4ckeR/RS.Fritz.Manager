namespace RS.Fritz.Manager.API;

using System.ServiceModel;
using System.Threading.Tasks;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANPPPConnection:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanPppConnectionService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetInfo")]
    public Task<WanPppConnectionGetInfoResponse> GetInfoAsync(WanPppConnectionGetInfoRequest wanPppConnectionGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetConnectionTypeInfo")]
    public Task<WanPppConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanPppConnectionGetConnectionTypeInfoRequest wanPppConnectionGetConnectionTypeInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetStatusInfo")]
    public Task<WanPppConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanPppConnectionGetStatusInfoRequest wanPppConnectionGetStatusInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetLinkLayerMaxBitRates")]
    public Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> GetLinkLayerMaxBitRatesAsync(WanPppConnectionGetLinkLayerMaxBitRatesRequest wanPppConnectionGetLinkLayerMaxBitRatesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetUserName")]
    public Task<WanPppConnectionGetUserNameResponse> GetUserNameAsync(WanPppConnectionGetUserNameRequest wanPppConnectionGetUserNameRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetNATRSIPStatus")]
    public Task<WanPppConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanPppConnectionGetNatRsipStatusRequest wanPppConnectionGetNatRsipStatusRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#X_GetDNSServers")]
    public Task<WanPppConnectionGetDnsServersResponse> GetDnsServersAsync(WanPppConnectionGetDnsServersRequest wanPppConnectionGetDnsServersRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetPortMappingNumberOfEntries")]
    public Task<WanPppConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanPppConnectionGetPortMappingNumberOfEntriesRequest wanPppConnectionGetPortMappingNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#GetExternalIPAddress")]
    public Task<WanPppConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanPppConnectionGetExternalIpAddressRequest wanPppConnectionGetExternalIpAddressRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANPPPConnection:1#X_AVM-DE_GetAutoDisconnectTimeSpan")]
    public Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> GetAutoDisconnectTimeSpanAsync(WanPppConnectionGetAutoDisconnectTimeSpanRequest wanPppConnectionGetAutoDisconnectTimeSpanRequest);
}
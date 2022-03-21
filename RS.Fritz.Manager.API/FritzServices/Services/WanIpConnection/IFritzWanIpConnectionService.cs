namespace RS.Fritz.Manager.API;

using System.ServiceModel;
using System.Threading.Tasks;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANIPConnection:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanIpConnectionService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetInfo")]
    public Task<WanIpConnectionGetInfoResponse> GetInfoAsync(WanConnectionGetInfoRequest wanConnectionGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetConnectionTypeInfo")]
    public Task<WanConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanConnectionGetConnectionTypeInfoRequest wanConnectionGetConnectionTypeInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetStatusInfo")]
    public Task<WanConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanConnectionGetStatusInfoRequest wanConnectionGetStatusInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetNATRSIPStatus")]
    public Task<WanConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanConnectionGetNatRsipStatusRequest wanConnectionGetNatRsipStatusRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#X_GetDNSServers")]
    public Task<WanConnectionGetDnsServersResponse> GetDnsServersAsync(WanConnectionGetDnsServersRequest wanConnectionGetDnsServersRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetPortMappingNumberOfEntries")]
    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanConnectionGetPortMappingNumberOfEntriesRequest wanConnectionGetPortMappingNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetExternalIPAddress")]
    public Task<WanConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanConnectionGetExternalIpAddressRequest wanConnectionGetExternalIpAddressRequest);
}
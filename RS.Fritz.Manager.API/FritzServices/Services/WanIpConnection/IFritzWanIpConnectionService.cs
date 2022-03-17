namespace RS.Fritz.Manager.API;

using System.ServiceModel;
using System.Threading.Tasks;

[ServiceContract(Namespace = "urn:dslforum-org:service:WANIPConnection:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWanIpConnectionService
{
    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetInfo")]
    public Task<WanIpConnectionGetInfoResponse> GetInfoAsync(WanIpConnectionGetInfoRequest wanIpConnectionGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetConnectionTypeInfo")]
    public Task<WanIpConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanIpConnectionGetConnectionTypeInfoRequest wanIpConnectionGetConnectionTypeInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetStatusInfo")]
    public Task<WanIpConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanIpConnectionGetStatusInfoRequest wanIpConnectionGetStatusInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetNATRSIPStatus")]
    public Task<WanIpConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanIpConnectionGetNatRsipStatusRequest wanIpConnectionGetNatRsipStatusRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#X_GetDNSServers")]
    public Task<WanIpConnectionGetDnsServersResponse> GetDnsServersAsync(WanIpConnectionGetDnsServersRequest wanIpConnectionGetDnsServersRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetPortMappingNumberOfEntries")]
    public Task<WanIpConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanIpConnectionGetPortMappingNumberOfEntriesRequest wanIpConnectionGetPortMappingNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WANIPConnection:1#GetExternalIPAddress")]
    public Task<WanIpConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanIpConnectionGetExternalIpAddressRequest wanIpConnectionGetExternalIpAddressRequest);
}
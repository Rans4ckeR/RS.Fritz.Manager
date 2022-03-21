namespace RS.Fritz.Manager.API;

using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;

internal sealed class FritzWanIpConnectionService : FritzServiceClient<IFritzWanIpConnectionService>, IFritzWanIpConnectionService
{
    public const string ControlUrl = "/upnp/control/wanipconnection1";

    public FritzWanIpConnectionService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WanIpConnectionGetInfoResponse> GetInfoAsync(WanConnectionGetInfoRequest wanConnectionGetInfoRequest)
    {
        return Channel.GetInfoAsync(wanConnectionGetInfoRequest);
    }

    public Task<WanConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanConnectionGetConnectionTypeInfoRequest wanConnectionGetConnectionTypeInfoRequest)
    {
        return Channel.GetConnectionTypeInfoAsync(wanConnectionGetConnectionTypeInfoRequest);
    }

    public Task<WanConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanConnectionGetStatusInfoRequest wanConnectionGetStatusInfoRequest)
    {
        return Channel.GetStatusInfoAsync(wanConnectionGetStatusInfoRequest);
    }

    public Task<WanConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanConnectionGetNatRsipStatusRequest wanConnectionGetNatRsipStatusRequest)
    {
        return Channel.GetNatRsipStatusAsync(wanConnectionGetNatRsipStatusRequest);
    }

    public Task<WanConnectionGetDnsServersResponse> GetDnsServersAsync(WanConnectionGetDnsServersRequest wanConnectionGetDnsServersRequest)
    {
        return Channel.GetDnsServersAsync(wanConnectionGetDnsServersRequest);
    }

    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanConnectionGetPortMappingNumberOfEntriesRequest wanConnectionGetPortMappingNumberOfEntriesRequest)
    {
        return Channel.GetPortMappingNumberOfEntriesAsync(wanConnectionGetPortMappingNumberOfEntriesRequest);
    }

    public Task<WanConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanConnectionGetExternalIpAddressRequest wanConnectionGetExternalIpAddressRequest)
    {
        return Channel.GetExternalIpAddressAsync(wanConnectionGetExternalIpAddressRequest);
    }
}
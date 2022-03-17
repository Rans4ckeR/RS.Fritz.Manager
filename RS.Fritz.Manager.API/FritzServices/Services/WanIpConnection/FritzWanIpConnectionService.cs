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

    public Task<WanIpConnectionGetInfoResponse> GetInfoAsync(WanIpConnectionGetInfoRequest wanIpConnectionGetInfoRequest)
    {
        return Channel.GetInfoAsync(wanIpConnectionGetInfoRequest);
    }

    public Task<WanIpConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanIpConnectionGetConnectionTypeInfoRequest wanIpConnectionGetConnectionTypeInfoRequest)
    {
        return Channel.GetConnectionTypeInfoAsync(wanIpConnectionGetConnectionTypeInfoRequest);
    }

    public Task<WanIpConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanIpConnectionGetStatusInfoRequest wanIpConnectionGetStatusInfoRequest)
    {
        return Channel.GetStatusInfoAsync(wanIpConnectionGetStatusInfoRequest);
    }

    public Task<WanIpConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanIpConnectionGetNatRsipStatusRequest wanIpConnectionGetNatRsipStatusRequest)
    {
        return Channel.GetNatRsipStatusAsync(wanIpConnectionGetNatRsipStatusRequest);
    }

    public Task<WanIpConnectionGetDnsServersResponse> GetDnsServersAsync(WanIpConnectionGetDnsServersRequest wanIpConnectionGetDnsServersRequest)
    {
        return Channel.GetDnsServersAsync(wanIpConnectionGetDnsServersRequest);
    }

    public Task<WanIpConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanIpConnectionGetPortMappingNumberOfEntriesRequest wanIpConnectionGetPortMappingNumberOfEntriesRequest)
    {
        return Channel.GetPortMappingNumberOfEntriesAsync(wanIpConnectionGetPortMappingNumberOfEntriesRequest);
    }

    public Task<WanIpConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanIpConnectionGetExternalIpAddressRequest wanIpConnectionGetExternalIpAddressRequest)
    {
        return Channel.GetExternalIpAddressAsync(wanIpConnectionGetExternalIpAddressRequest);
    }
}
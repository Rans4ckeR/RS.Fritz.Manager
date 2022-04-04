namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzWanPppConnectionService : FritzServiceClient<IFritzWanPppConnectionService>, IFritzWanPppConnectionService
{
    public const string ControlUrl = "/upnp/control/wanpppconn1";

    public FritzWanPppConnectionService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WanPppConnectionGetInfoResponse> GetInfoAsync(WanConnectionGetInfoRequest wanConnectionGetInfoRequest)
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

    public Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> GetLinkLayerMaxBitRatesAsync(WanPppConnectionGetLinkLayerMaxBitRatesRequest wanPppConnectionGetLinkLayerMaxBitRatesRequest)
    {
        return Channel.GetLinkLayerMaxBitRatesAsync(wanPppConnectionGetLinkLayerMaxBitRatesRequest);
    }

    public Task<WanPppConnectionGetUserNameResponse> GetUserNameAsync(WanPppConnectionGetUserNameRequest wanPppConnectionGetUserNameRequest)
    {
        return Channel.GetUserNameAsync(wanPppConnectionGetUserNameRequest);
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

    public Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> GetAutoDisconnectTimeSpanAsync(WanPppConnectionGetAutoDisconnectTimeSpanRequest wanPppConnectionGetAutoDisconnectTimeSpanRequest)
    {
        return Channel.GetAutoDisconnectTimeSpanAsync(wanPppConnectionGetAutoDisconnectTimeSpanRequest);
    }

    public Task<WanConnectionGetGenericPortMappingEntryResponse> GetGenericPortMappingEntryAsync(WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest)
    {
        return Channel.GetGenericPortMappingEntryAsync(wanConnectionGetGenericPortMappingEntryRequest);
    }
}
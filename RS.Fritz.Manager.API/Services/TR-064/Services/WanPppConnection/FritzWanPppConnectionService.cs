using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzWanPppConnectionService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzWanPppConnectionService>(endpointConfiguration, remoteAddress, networkCredential), IFritzWanPppConnectionService
{
    public const string ControlUrl = "/upnp/control/wanpppconn1";

    public Task<WanPppConnectionGetInfoResponse> GetInfoAsync(WanConnectionGetInfoRequest wanConnectionGetInfoRequest)
        => Channel.GetInfoAsync(wanConnectionGetInfoRequest);

    public Task<WanConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanConnectionGetConnectionTypeInfoRequest wanConnectionGetConnectionTypeInfoRequest)
        => Channel.GetConnectionTypeInfoAsync(wanConnectionGetConnectionTypeInfoRequest);

    public Task<WanConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanConnectionGetStatusInfoRequest wanConnectionGetStatusInfoRequest)
        => Channel.GetStatusInfoAsync(wanConnectionGetStatusInfoRequest);

    public Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> GetLinkLayerMaxBitRatesAsync(WanPppConnectionGetLinkLayerMaxBitRatesRequest wanPppConnectionGetLinkLayerMaxBitRatesRequest)
        => Channel.GetLinkLayerMaxBitRatesAsync(wanPppConnectionGetLinkLayerMaxBitRatesRequest);

    public Task<WanPppConnectionGetUserNameResponse> GetUserNameAsync(WanPppConnectionGetUserNameRequest wanPppConnectionGetUserNameRequest)
        => Channel.GetUserNameAsync(wanPppConnectionGetUserNameRequest);

    public Task<WanConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanConnectionGetNatRsipStatusRequest wanConnectionGetNatRsipStatusRequest)
        => Channel.GetNatRsipStatusAsync(wanConnectionGetNatRsipStatusRequest);

    public Task<WanConnectionGetDnsServersResponse> GetDnsServersAsync(WanConnectionGetDnsServersRequest wanConnectionGetDnsServersRequest)
        => Channel.GetDnsServersAsync(wanConnectionGetDnsServersRequest);

    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanConnectionGetPortMappingNumberOfEntriesRequest wanConnectionGetPortMappingNumberOfEntriesRequest)
        => Channel.GetPortMappingNumberOfEntriesAsync(wanConnectionGetPortMappingNumberOfEntriesRequest);

    public Task<WanConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanConnectionGetExternalIpAddressRequest wanConnectionGetExternalIpAddressRequest)
        => Channel.GetExternalIpAddressAsync(wanConnectionGetExternalIpAddressRequest);

    public Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> GetAutoDisconnectTimeSpanAsync(WanPppConnectionGetAutoDisconnectTimeSpanRequest wanPppConnectionGetAutoDisconnectTimeSpanRequest)
        => Channel.GetAutoDisconnectTimeSpanAsync(wanPppConnectionGetAutoDisconnectTimeSpanRequest);

    public Task<WanConnectionGetGenericPortMappingEntryResponse> GetGenericPortMappingEntryAsync(WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest)
        => Channel.GetGenericPortMappingEntryAsync(wanConnectionGetGenericPortMappingEntryRequest);
}
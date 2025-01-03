﻿using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzWanIpConnectionService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzWanIpConnectionService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzWanIpConnectionService
{
    public Task<WanIpConnectionGetInfoResponse> GetInfoAsync(WanConnectionGetInfoRequest wanConnectionGetInfoRequest)
        => Channel.GetInfoAsync(wanConnectionGetInfoRequest);

    public Task<WanConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanConnectionGetConnectionTypeInfoRequest wanConnectionGetConnectionTypeInfoRequest)
        => Channel.GetConnectionTypeInfoAsync(wanConnectionGetConnectionTypeInfoRequest);

    public Task<WanConnectionGetStatusInfoResponse> GetStatusInfoAsync(WanConnectionGetStatusInfoRequest wanConnectionGetStatusInfoRequest)
        => Channel.GetStatusInfoAsync(wanConnectionGetStatusInfoRequest);

    public Task<WanConnectionGetNatRsipStatusResponse> GetNatRsipStatusAsync(WanConnectionGetNatRsipStatusRequest wanConnectionGetNatRsipStatusRequest)
        => Channel.GetNatRsipStatusAsync(wanConnectionGetNatRsipStatusRequest);

    public Task<WanConnectionGetDnsServersResponse> GetDnsServersAsync(WanConnectionGetDnsServersRequest wanConnectionGetDnsServersRequest)
        => Channel.GetDnsServersAsync(wanConnectionGetDnsServersRequest);

    public Task<WanConnectionGetPortMappingNumberOfEntriesResponse> GetPortMappingNumberOfEntriesAsync(WanConnectionGetPortMappingNumberOfEntriesRequest wanConnectionGetPortMappingNumberOfEntriesRequest)
        => Channel.GetPortMappingNumberOfEntriesAsync(wanConnectionGetPortMappingNumberOfEntriesRequest);

    public Task<WanConnectionGetExternalIpAddressResponse> GetExternalIpAddressAsync(WanConnectionGetExternalIpAddressRequest wanConnectionGetExternalIpAddressRequest)
        => Channel.GetExternalIpAddressAsync(wanConnectionGetExternalIpAddressRequest);

    public Task<WanConnectionGetGenericPortMappingEntryResponse> GetGenericPortMappingEntryAsync(WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest)
        => Channel.GetGenericPortMappingEntryAsync(wanConnectionGetGenericPortMappingEntryRequest);
}
using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzWanDslLinkConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzWanDslLinkConfigService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzWanDslLinkConfigService
{
    public Task<WanDslLinkConfigGetInfoResponse> GetInfoAsync(WanDslLinkConfigGetInfoRequest wanDslLinkConfigGetInfoRequest)
        => Channel.GetInfoAsync(wanDslLinkConfigGetInfoRequest);

    public Task<WanDslLinkConfigGetDslLinkInfoResponse> GetDslLinkInfoAsync(WanDslLinkConfigGetDslLinkInfoRequest wanDslLinkConfigGetDslLinkInfoRequest)
        => Channel.GetDslLinkInfoAsync(wanDslLinkConfigGetDslLinkInfoRequest);

    public Task<WanDslLinkConfigGetDestinationAddressResponse> GetDestinationAddressAsync(WanDslLinkConfigGetDestinationAddressRequest wanDslLinkConfigGetDestinationAddressRequest)
        => Channel.GetDestinationAddressAsync(wanDslLinkConfigGetDestinationAddressRequest);

    public Task<WanDslLinkConfigGetAtmEncapsulationResponse> GetAtmEncapsulationAsync(WanDslLinkConfigGetAtmEncapsulationRequest wanDslLinkConfigGetAtmEncapsulationRequest)
        => Channel.GetAtmEncapsulationAsync(wanDslLinkConfigGetAtmEncapsulationRequest);

    public Task<WanDslLinkConfigGetAutoConfigResponse> GetAutoConfigAsync(WanDslLinkConfigGetAutoConfigRequest wanDslLinkConfigGetAutoConfigRequest)
        => Channel.GetAutoConfigAsync(wanDslLinkConfigGetAutoConfigRequest);

    public Task<WanDslLinkConfigGetStatisticsResponse> GetStatisticsAsync(WanDslLinkConfigGetStatisticsRequest wanDslLinkConfigGetStatisticsRequest)
        => Channel.GetStatisticsAsync(wanDslLinkConfigGetStatisticsRequest);
}
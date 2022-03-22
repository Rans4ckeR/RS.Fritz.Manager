namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzWanDslLinkConfigService : FritzServiceClient<IFritzWanDslLinkConfigService>, IFritzWanDslLinkConfigService
{
    public const string ControlUrl = "/upnp/control/wandsllinkconfig1";

    public FritzWanDslLinkConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WanDslLinkConfigGetInfoResponse> GetInfoAsync(WanDslLinkConfigGetInfoRequest wanDslLinkConfigGetInfoRequest)
    {
        return Channel.GetInfoAsync(wanDslLinkConfigGetInfoRequest);
    }

    public Task<WanDslLinkConfigGetDslLinkInfoResponse> GetDslLinkInfoAsync(WanDslLinkConfigGetDslLinkInfoRequest wanDslLinkConfigGetDslLinkInfoRequest)
    {
        return Channel.GetDslLinkInfoAsync(wanDslLinkConfigGetDslLinkInfoRequest);
    }

    public Task<WanDslLinkConfigGetDestinationAddressResponse> GetDestinationAddressAsync(WanDslLinkConfigGetDestinationAddressRequest wanDslLinkConfigGetDestinationAddressRequest)
    {
        return Channel.GetDestinationAddressAsync(wanDslLinkConfigGetDestinationAddressRequest);
    }

    public Task<WanDslLinkConfigGetAtmEncapsulationResponse> GetAtmEncapsulationAsync(WanDslLinkConfigGetAtmEncapsulationRequest wanDslLinkConfigGetAtmEncapsulationRequest)
    {
        return Channel.GetAtmEncapsulationAsync(wanDslLinkConfigGetAtmEncapsulationRequest);
    }

    public Task<WanDslLinkConfigGetAutoConfigResponse> GetAutoConfigAsync(WanDslLinkConfigGetAutoConfigRequest wanDslLinkConfigGetAutoConfigRequest)
    {
        return Channel.GetAutoConfigAsync(wanDslLinkConfigGetAutoConfigRequest);
    }

    public Task<WanDslLinkConfigGetStatisticsResponse> GetStatisticsAsync(WanDslLinkConfigGetStatisticsRequest wanDslLinkConfigGetStatisticsRequest)
    {
        return Channel.GetStatisticsAsync(wanDslLinkConfigGetStatisticsRequest);
    }
}
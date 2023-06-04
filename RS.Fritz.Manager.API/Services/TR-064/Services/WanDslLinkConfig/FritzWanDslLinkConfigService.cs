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
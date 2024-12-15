using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzWanEthernetLinkConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzWanEthernetLinkConfigService>(endpointConfiguration, remoteAddress, networkCredential), IFritzWanEthernetLinkConfigService
{
    public Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> GetEthernetLinkStatusAsync(WanEthernetLinkConfigGetEthernetLinkStatusRequest wanEthernetLinkConfigGetEthernetLinkStatusRequest)
        => Channel.GetEthernetLinkStatusAsync(wanEthernetLinkConfigGetEthernetLinkStatusRequest);
}
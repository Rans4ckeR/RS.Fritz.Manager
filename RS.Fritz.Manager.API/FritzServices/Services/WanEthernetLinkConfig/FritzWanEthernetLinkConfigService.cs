namespace RS.Fritz.Manager.API;

using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;

internal sealed class FritzWanEthernetLinkConfigService : FritzServiceClient<IFritzWanEthernetLinkConfigService>, IFritzWanEthernetLinkConfigService
{
    public const string ControlUrl = "/upnp/control/wanethlinkconfig1";

    public FritzWanEthernetLinkConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> GetEthernetLinkStatusAsync(WanEthernetLinkConfigGetEthernetLinkStatusRequest wanEthernetLinkConfigGetEthernetLinkStatusRequest)
    {
        return Channel.GetEthernetLinkStatusAsync(wanEthernetLinkConfigGetEthernetLinkStatusRequest);
    }
}
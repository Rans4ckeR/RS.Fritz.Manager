namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzLanEthernetInterfaceConfigService : FritzServiceClient<IFritzLanEthernetInterfaceConfigService>, IFritzLanEthernetInterfaceConfigService
{
    public const string ControlUrl = "/upnp/control/lanethernetifcfg";

    public FritzLanEthernetInterfaceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential = null)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<LanEthernetInterfaceConfigGetInfoResponse> GetInfoAsync(LanEthernetInterfaceConfigGetInfoRequest lanEthernetInterfaceConfigGetInfoRequest)
    {
        return Channel.GetInfoAsync(lanEthernetInterfaceConfigGetInfoRequest);
    }
}
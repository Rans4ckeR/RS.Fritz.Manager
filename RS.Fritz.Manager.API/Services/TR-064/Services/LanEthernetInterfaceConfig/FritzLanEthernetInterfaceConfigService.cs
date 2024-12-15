using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzLanEthernetInterfaceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzLanEthernetInterfaceConfigService>(endpointConfiguration, remoteAddress, networkCredential), IFritzLanEthernetInterfaceConfigService
{
    public const string ControlUrl = "/upnp/control/lanethernetifcfg";

    public Task<LanEthernetInterfaceConfigGetInfoResponse> GetInfoAsync(LanEthernetInterfaceConfigGetInfoRequest lanEthernetInterfaceConfigGetInfoRequest)
        => Channel.GetInfoAsync(lanEthernetInterfaceConfigGetInfoRequest);

    public Task<LanEthernetInterfaceConfigGetStatisticsResponse> GetStatisticsAsync(LanEthernetInterfaceConfigGetStatisticsRequest lanEthernetInterfaceConfigGetStatisticsRequest)
        => Channel.GetStatisticsAsync(lanEthernetInterfaceConfigGetStatisticsRequest);
}
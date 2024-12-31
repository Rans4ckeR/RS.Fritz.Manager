using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzLanEthernetInterfaceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzLanEthernetInterfaceConfigService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzLanEthernetInterfaceConfigService
{
    public const string ControlUrl = "/upnp/control/lanethernetifcfg";

    public Task<LanEthernetInterfaceConfigGetInfoResponse> GetInfoAsync(LanEthernetInterfaceConfigGetInfoRequest lanEthernetInterfaceConfigGetInfoRequest)
        => Channel.GetInfoAsync(lanEthernetInterfaceConfigGetInfoRequest);

    public Task<LanEthernetInterfaceConfigGetStatisticsResponse> GetStatisticsAsync(LanEthernetInterfaceConfigGetStatisticsRequest lanEthernetInterfaceConfigGetStatisticsRequest)
        => Channel.GetStatisticsAsync(lanEthernetInterfaceConfigGetStatisticsRequest);
}
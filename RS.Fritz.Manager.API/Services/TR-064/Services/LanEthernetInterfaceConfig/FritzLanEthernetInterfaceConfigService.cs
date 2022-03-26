namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzLanEthernetInterfaceConfigService : FritzServiceClient<IFritzLanEthernetInterfaceConfigService>, IFritzLanEthernetInterfaceConfigService
{
    public const string ControlUrl = "/upnp/control/lanethernetifcfg";

    public FritzLanEthernetInterfaceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<LanEthernetInterfaceConfigGetInfoResponse> GetInfoAsync(LanEthernetInterfaceConfigGetInfoRequest lanEthernetInterfaceConfigGetInfoRequest)
    {
        return Channel.GetInfoAsync(lanEthernetInterfaceConfigGetInfoRequest);
    }

    public Task<LanEthernetInterfaceConfigGetStatisticsResponse> GetStatisticsAsync(LanEthernetInterfaceConfigGetStatisticsRequest lanEthernetInterfaceConfigGetStatisticsRequest)
    {
        return Channel.GetStatisticsAsync(lanEthernetInterfaceConfigGetStatisticsRequest);
    }
}
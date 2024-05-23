namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzLanEthernetInterfaceConfigService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzLanEthernetInterfaceConfigService>(binding, remoteAddress), IFritzLanEthernetInterfaceConfigService
{
    public Task<LanEthernetInterfaceConfigGetInfoResponse> GetInfoAsync(LanEthernetInterfaceConfigGetInfoRequest lanEthernetInterfaceConfigGetInfoRequest)
        => Channel.GetInfoAsync(lanEthernetInterfaceConfigGetInfoRequest);

    public Task<LanEthernetInterfaceConfigGetStatisticsResponse> GetStatisticsAsync(LanEthernetInterfaceConfigGetStatisticsRequest lanEthernetInterfaceConfigGetStatisticsRequest)
        => Channel.GetStatisticsAsync(lanEthernetInterfaceConfigGetStatisticsRequest);
}
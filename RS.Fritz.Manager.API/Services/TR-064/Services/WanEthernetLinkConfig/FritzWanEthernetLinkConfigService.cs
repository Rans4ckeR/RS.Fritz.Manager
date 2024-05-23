namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzWanEthernetLinkConfigService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzWanEthernetLinkConfigService>(binding, remoteAddress), IFritzWanEthernetLinkConfigService
{
    public Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> GetEthernetLinkStatusAsync(WanEthernetLinkConfigGetEthernetLinkStatusRequest wanEthernetLinkConfigGetEthernetLinkStatusRequest)
        => Channel.GetEthernetLinkStatusAsync(wanEthernetLinkConfigGetEthernetLinkStatusRequest);
}
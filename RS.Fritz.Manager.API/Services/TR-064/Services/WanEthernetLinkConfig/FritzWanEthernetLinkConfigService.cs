﻿namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzWanEthernetLinkConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzWanEthernetLinkConfigService>(endpointConfiguration, remoteAddress, networkCredential), IFritzWanEthernetLinkConfigService
{
    public const string ControlUrl = "/upnp/control/wanethlinkconfig1";

    public Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> GetEthernetLinkStatusAsync(WanEthernetLinkConfigGetEthernetLinkStatusRequest wanEthernetLinkConfigGetEthernetLinkStatusRequest)
        => Channel.GetEthernetLinkStatusAsync(wanEthernetLinkConfigGetEthernetLinkStatusRequest);
}
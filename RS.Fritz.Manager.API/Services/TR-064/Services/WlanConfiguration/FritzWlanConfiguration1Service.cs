namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzWlanConfiguration1Service : FritzServiceClient<IFritzWlanConfiguration1Service>, IFritzWlanConfiguration1Service
{
    public const string ControlUrl = "/upnp/control/wlanconfig1";

    public FritzWlanConfiguration1Service(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest)
    {
        return Channel.GetInfoAsync(wlanConfigurationGetInfoRequest);
    }
}
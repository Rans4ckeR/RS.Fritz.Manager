namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzWlanConfiguration3Service : FritzServiceClient<IFritzWlanConfiguration3Service>, IFritzWlanConfiguration3Service
{
    public const string ControlUrl = "/upnp/control/wlanconfig3";

    public FritzWlanConfiguration3Service(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest)
    {
        return Channel.GetInfoAsync(wlanConfigurationGetInfoRequest);
    }
}
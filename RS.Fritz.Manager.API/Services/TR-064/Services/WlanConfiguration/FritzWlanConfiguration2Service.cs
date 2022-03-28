namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzWlanConfiguration2Service : FritzServiceClient<IFritzWlanConfiguration2Service>, IFritzWlanConfiguration2Service
{
    public const string ControlUrl = "/upnp/control/wlanconfig2";

    public FritzWlanConfiguration2Service(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest)
    {
        return Channel.GetInfoAsync(wlanConfigurationGetInfoRequest);
    }

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> GetWlanDeviceListPathAsync(WlanConfigurationGetWlanDeviceListPathRequest wlanConfigurationGetWlanDeviceListPathRequest)
    {
        return Channel.GetWlanDeviceListPathAsync(wlanConfigurationGetWlanDeviceListPathRequest);
    }
}
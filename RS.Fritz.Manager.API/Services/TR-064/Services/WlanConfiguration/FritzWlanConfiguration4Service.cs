namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzWlanConfiguration4Service : FritzServiceClient<IFritzWlanConfiguration4Service>, IFritzWlanConfiguration4Service
{
    public const string ControlUrl = "/upnp/control/wlanconfig4";

    public FritzWlanConfiguration4Service(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
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
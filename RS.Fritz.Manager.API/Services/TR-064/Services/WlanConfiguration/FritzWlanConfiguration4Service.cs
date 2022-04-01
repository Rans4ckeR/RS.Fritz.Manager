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

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> GetBasBeaconSecurityPropertiesAsync(WlanConfigurationGetBasBeaconSecurityPropertiesRequest wlanConfigurationGetBasBeaconSecurityPropertiesRequest)
    {
        return Channel.GetBasBeaconSecurityPropertiesAsync(wlanConfigurationGetBasBeaconSecurityPropertiesRequest);
    }

    public Task<WlanConfigurationGetBssIdResponse> GetBssIdAsync(WlanConfigurationGetBssIdRequest wlanConfigurationGetBssIdRequest)
    {
        return Channel.GetBssIdAsync(wlanConfigurationGetBssIdRequest);
    }

    public Task<WlanConfigurationGetSsIdResponse> GetSsIdAsync(WlanConfigurationGetSsIdRequest wlanConfigurationGetSsIdRequest)
    {
        return Channel.GetSsIdAsync(wlanConfigurationGetSsIdRequest);
    }

    public Task<WlanConfigurationGetBeaconTypeResponse> GetBeaconTypeAsync(WlanConfigurationGetBeaconTypeRequest wlanConfigurationGetBeaconTypeRequest)
    {
        return Channel.GetBeaconTypeAsync(wlanConfigurationGetBeaconTypeRequest);
    }

    public Task<WlanConfigurationGetChannelInfoResponse> GetChannelInfoAsync(WlanConfigurationGetChannelInfoRequest wlanConfigurationGetChannelInfoRequest)
    {
        return Channel.GetChannelInfoAsync(wlanConfigurationGetChannelInfoRequest);
    }

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> GetBeaconAdvertisementAsync(WlanConfigurationGetBeaconAdvertisementRequest wlanConfigurationGetBeaconAdvertisementRequest)
    {
        return Channel.GetBeaconAdvertisementAsync(wlanConfigurationGetBeaconAdvertisementRequest);
    }

    public Task<WlanConfigurationGetTotalAssociationsResponse> GetTotalAssociationsAsync(WlanConfigurationGetTotalAssociationsRequest wlanConfigurationGetTotalAssociationsRequest)
    {
        return Channel.GetTotalAssociationsAsync(wlanConfigurationGetTotalAssociationsRequest);
    }

    public Task<WlanConfigurationGetIpTvOptimizedResponse> GetIpTvOptimizedAsync(WlanConfigurationGetIpTvOptimizedRequest wlanConfigurationGetIpTvOptimizedRequest)
    {
        return Channel.GetIpTvOptimizedAsync(wlanConfigurationGetIpTvOptimizedRequest);
    }

    public Task<WlanConfigurationGetStatisticsResponse> GetStatisticsAsync(WlanConfigurationGetStatisticsRequest wlanConfigurationGetStatisticsRequest)
    {
        return Channel.GetStatisticsAsync(wlanConfigurationGetStatisticsRequest);
    }

    public Task<WlanConfigurationGetPacketStatisticsResponse> GetPacketStatisticsAsync(WlanConfigurationGetPacketStatisticsRequest wlanConfigurationGetPacketStatisticsRequest)
    {
        return Channel.GetPacketStatisticsAsync(wlanConfigurationGetPacketStatisticsRequest);
    }

    public Task<WlanConfigurationGetNightControlResponse> GetNightControlAsync(WlanConfigurationGetNightControlRequest wlanConfigurationGetNightControlRequest)
    {
        return Channel.GetNightControlAsync(wlanConfigurationGetNightControlRequest);
    }

    public Task<WlanConfigurationGetWlanHybridModeResponse> GetWlanHybridModeAsync(WlanConfigurationGetWlanHybridModeRequest wlanConfigurationGetWlanHybridModeRequest)
    {
        return Channel.GetWlanHybridModeAsync(wlanConfigurationGetWlanHybridModeRequest);
    }

    public Task<WlanConfigurationGetWlanExtInfoResponse> GetWlanExtInfoAsync(WlanConfigurationGetWlanExtInfoRequest wlanConfigurationGetWlanExtInfoRequest)
    {
        return Channel.GetWlanExtInfoAsync(wlanConfigurationGetWlanExtInfoRequest);
    }

    public Task<WlanConfigurationGetWpsInfoResponse> GetWpsInfoAsync(WlanConfigurationGetWpsInfoRequest wlanConfigurationGetWpsInfoRequest)
    {
        return Channel.GetWpsInfoAsync(wlanConfigurationGetWpsInfoRequest);
    }

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> GetWlanConnectionInfoAsync(WlanConfigurationGetWlanConnectionInfoRequest wlanConfigurationGetWlanConnectionInfoRequest)
    {
        return Channel.GetWlanConnectionInfoAsync(wlanConfigurationGetWlanConnectionInfoRequest);
    }
}
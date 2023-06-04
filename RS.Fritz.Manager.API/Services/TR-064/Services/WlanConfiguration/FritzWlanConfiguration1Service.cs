﻿namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzWlanConfiguration1Service : FritzServiceClient<IFritzWlanConfiguration1Service>, IFritzWlanConfiguration1Service
{
    public const string ControlUrl = "/upnp/control/wlanconfig1";

    public FritzWlanConfiguration1Service(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest)
        => Channel.GetInfoAsync(wlanConfigurationGetInfoRequest);

    public Task<WlanConfigurationGetWlanDeviceListPathResponse> GetWlanDeviceListPathAsync(WlanConfigurationGetWlanDeviceListPathRequest wlanConfigurationGetWlanDeviceListPathRequest)
        => Channel.GetWlanDeviceListPathAsync(wlanConfigurationGetWlanDeviceListPathRequest);

    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> GetBasBeaconSecurityPropertiesAsync(WlanConfigurationGetBasBeaconSecurityPropertiesRequest wlanConfigurationGetBasBeaconSecurityPropertiesRequest)
        => Channel.GetBasBeaconSecurityPropertiesAsync(wlanConfigurationGetBasBeaconSecurityPropertiesRequest);

    public Task<WlanConfigurationGetBssIdResponse> GetBssIdAsync(WlanConfigurationGetBssIdRequest wlanConfigurationGetBssIdRequest)
        => Channel.GetBssIdAsync(wlanConfigurationGetBssIdRequest);

    public Task<WlanConfigurationGetSsIdResponse> GetSsIdAsync(WlanConfigurationGetSsIdRequest wlanConfigurationGetSsIdRequest)
        => Channel.GetSsIdAsync(wlanConfigurationGetSsIdRequest);

    public Task<WlanConfigurationGetBeaconTypeResponse> GetBeaconTypeAsync(WlanConfigurationGetBeaconTypeRequest wlanConfigurationGetBeaconTypeRequest)
        => Channel.GetBeaconTypeAsync(wlanConfigurationGetBeaconTypeRequest);

    public Task<WlanConfigurationGetChannelInfoResponse> GetChannelInfoAsync(WlanConfigurationGetChannelInfoRequest wlanConfigurationGetChannelInfoRequest)
        => Channel.GetChannelInfoAsync(wlanConfigurationGetChannelInfoRequest);

    public Task<WlanConfigurationGetBeaconAdvertisementResponse> GetBeaconAdvertisementAsync(WlanConfigurationGetBeaconAdvertisementRequest wlanConfigurationGetBeaconAdvertisementRequest)
        => Channel.GetBeaconAdvertisementAsync(wlanConfigurationGetBeaconAdvertisementRequest);

    public Task<WlanConfigurationGetTotalAssociationsResponse> GetTotalAssociationsAsync(WlanConfigurationGetTotalAssociationsRequest wlanConfigurationGetTotalAssociationsRequest)
        => Channel.GetTotalAssociationsAsync(wlanConfigurationGetTotalAssociationsRequest);

    public Task<WlanConfigurationGetIpTvOptimizedResponse> GetIpTvOptimizedAsync(WlanConfigurationGetIpTvOptimizedRequest wlanConfigurationGetIpTvOptimizedRequest)
        => Channel.GetIpTvOptimizedAsync(wlanConfigurationGetIpTvOptimizedRequest);

    public Task<WlanConfigurationGetStatisticsResponse> GetStatisticsAsync(WlanConfigurationGetStatisticsRequest wlanConfigurationGetStatisticsRequest)
        => Channel.GetStatisticsAsync(wlanConfigurationGetStatisticsRequest);

    public Task<WlanConfigurationGetPacketStatisticsResponse> GetPacketStatisticsAsync(WlanConfigurationGetPacketStatisticsRequest wlanConfigurationGetPacketStatisticsRequest)
        => Channel.GetPacketStatisticsAsync(wlanConfigurationGetPacketStatisticsRequest);

    public Task<WlanConfigurationGetNightControlResponse> GetNightControlAsync(WlanConfigurationGetNightControlRequest wlanConfigurationGetNightControlRequest)
        => Channel.GetNightControlAsync(wlanConfigurationGetNightControlRequest);

    public Task<WlanConfigurationGetWlanHybridModeResponse> GetWlanHybridModeAsync(WlanConfigurationGetWlanHybridModeRequest wlanConfigurationGetWlanHybridModeRequest)
        => Channel.GetWlanHybridModeAsync(wlanConfigurationGetWlanHybridModeRequest);

    public Task<WlanConfigurationGetWlanExtInfoResponse> GetWlanExtInfoAsync(WlanConfigurationGetWlanExtInfoRequest wlanConfigurationGetWlanExtInfoRequest)
        => Channel.GetWlanExtInfoAsync(wlanConfigurationGetWlanExtInfoRequest);

    public Task<WlanConfigurationGetWpsInfoResponse> GetWpsInfoAsync(WlanConfigurationGetWpsInfoRequest wlanConfigurationGetWpsInfoRequest)
        => Channel.GetWpsInfoAsync(wlanConfigurationGetWpsInfoRequest);

    public Task<WlanConfigurationGetWlanConnectionInfoResponse> GetWlanConnectionInfoAsync(WlanConfigurationGetWlanConnectionInfoRequest wlanConfigurationGetWlanConnectionInfoRequest)
        => Channel.GetWlanConnectionInfoAsync(wlanConfigurationGetWlanConnectionInfoRequest);
}
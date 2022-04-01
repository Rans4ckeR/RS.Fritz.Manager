﻿namespace RS.Fritz.Manager.API;

public interface IFritzServiceOperationHandler
{
    Task<HostsGetHostNumberOfEntriesResponse> HostsGetHostNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<HostsGetHostListPathResponse> HostsGetHostListPathAsync(InternetGatewayDevice internetGatewayDevice);

    Task<HostsGetGenericHostEntryResponse> HostsGetGenericHostEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort index);

    Task<HostsGetChangeCounterResponse> HostsGetChangeCounterAsync(InternetGatewayDevice internetGatewayDevice);

    Task<HostsGetMeshListPathResponse> HostsGetMeshListPathAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> WanCommonInterfaceConfigGetTotalBytesReceivedAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> WanCommonInterfaceConfigGetTotalBytesSentAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> WanCommonInterfaceConfigGetCommonLinkPropertiesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> WanCommonInterfaceConfigGetTotalPacketsSentAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> WanCommonInterfaceConfigGetOnlineMonitorAsync(InternetGatewayDevice internetGatewayDevice, uint syncGroupIndex);

    Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> WanCommonInterfaceConfigSetWanAccessTypeAsync(InternetGatewayDevice internetGatewayDevice, string accessType);

    Task<DeviceInfoGetInfoResponse> DeviceInfoGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync(InternetGatewayDevice internetGatewayDevice);

    Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync(InternetGatewayDevice internetGatewayDevice);

    Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(InternetGatewayDevice internetGatewayDevice, string provisioningCode);

    Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(InternetGatewayDevice internetGatewayDevice, string password);

    Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync(InternetGatewayDevice internetGatewayDevice);

    Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> Layer3ForwardingGetForwardNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<Layer3ForwardingGetGenericForwardingEntryResponse> Layer3ForwardingGetGenericForwardingEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort forwardingIndex);

    Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> WanDslInterfaceConfigGetDslDiagnoseInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslInterfaceConfigGetDslInfoResponse> WanDslInterfaceConfigGetDslInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanIpConnectionGetInfoResponse> WanIpConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetConnectionTypeInfoResponse> WanIpConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetStatusInfoResponse> WanIpConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetNatRsipStatusResponse> WanIpConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetDnsServersResponse> WanIpConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanIpConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetExternalIpAddressResponse> WanIpConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetGenericPortMappingEntryResponse> WanIpConnectionGetGenericPortMappingEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort portMappingIndex);

    Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetConnectionTypeInfoResponse> WanPppConnectionGetConnectionTypeInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetStatusInfoResponse> WanPppConnectionGetStatusInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> WanPppConnectionGetLinkLayerMaxBitRatesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanPppConnectionGetUserNameResponse> WanPppConnectionGetUserNameAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetNatRsipStatusResponse> WanPppConnectionGetNatRsipStatusAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetDnsServersResponse> WanPppConnectionGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanPppConnectionGetPortMappingNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetExternalIpAddressResponse> WanPppConnectionGetExternalIpAddressAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> WanPppConnectionGetAutoDisconnectTimeSpanAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanConnectionGetGenericPortMappingEntryResponse> WanPppConnectionGetGenericPortMappingEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort portMappingIndex);

    Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> WanEthernetLinkConfigGetEthernetLinkStatusAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslLinkConfigGetInfoResponse> WanDslLinkConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslLinkConfigGetDslLinkInfoResponse> WanDslLinkConfigGetDslLinkInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslLinkConfigGetDestinationAddressResponse> WanDslLinkConfigGetDestinationAddressAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslLinkConfigGetAtmEncapsulationResponse> WanDslLinkConfigGetAtmEncapsulationAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslLinkConfigGetAutoConfigResponse> WanDslLinkConfigGetAutoConfigAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslLinkConfigGetStatisticsResponse> WanDslLinkConfigGetStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<AvmSpeedtestGetInfoResponse> AvmSpeedtestGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanEthernetInterfaceConfigGetInfoResponse> LanEthernetInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanEthernetInterfaceConfigGetStatisticsResponse> LanEthernetInterfaceConfigGetStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanHostConfigManagementGetInfoResponse> LanHostConfigManagementGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanHostConfigManagementGetAddressRangeResponse> LanHostConfigManagementGetAddressRangeAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanHostConfigManagementGetDnsServersResponse> LanHostConfigManagementGetDnsServersAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse> LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanHostConfigManagementGetIpRoutersListResponse> LanHostConfigManagementGetIpRoutersListAsync(InternetGatewayDevice internetGatewayDevice);

    Task<LanHostConfigManagementGetSubnetMaskResponse> LanHostConfigManagementGetSubnetMaskAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetInfoResponse> WlanConfiguration1GetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetInfoResponse> WlanConfiguration2GetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetInfoResponse> WlanConfiguration3GetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetInfoResponse> WlanConfiguration4GetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration1GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration2GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration3GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfiguration4GetWlanDeviceListPathAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration1GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration2GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration3GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfiguration4GetBasBeaconSecurityPropertiesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBssIdResponse> WlanConfiguration1GetBssIdAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBssIdResponse> WlanConfiguration2GetBssIdAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBssIdResponse> WlanConfiguration3GetBssIdAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBssIdResponse> WlanConfiguration4GetBssIdAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetSsIdResponse> WlanConfiguration1GetSsIdAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetSsIdResponse> WlanConfiguration2GetSsIdAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetSsIdResponse> WlanConfiguration3GetSsIdAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetSsIdResponse> WlanConfiguration4GetSsIdAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration1GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration2GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration3GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBeaconTypeResponse> WlanConfiguration4GetBeaconTypeAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration1GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration2GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration3GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetChannelInfoResponse> WlanConfiguration4GetChannelInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration1GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration2GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration3GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfiguration4GetBeaconAdvertisementAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration1GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration2GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration3GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfiguration4GetTotalAssociationsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration1GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration2GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration3GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfiguration4GetIpTvOptimizedAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration1GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration2GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration3GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetStatisticsResponse> WlanConfiguration4GetStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration1GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration2GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration3GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfiguration4GetPacketStatisticsAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetNightControlResponse> WlanConfiguration1GetNightControlAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetNightControlResponse> WlanConfiguration2GetNightControlAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetNightControlResponse> WlanConfiguration3GetNightControlAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetNightControlResponse> WlanConfiguration4GetNightControlAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration1GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration2GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration3GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfiguration4GetWlanHybridModeAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration1GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration2GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration3GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfiguration4GetWlanExtInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration1GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration2GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration3GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWpsInfoResponse> WlanConfiguration4GetWpsInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration1GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration2GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration3GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfiguration4GetWlanConnectionInfoAsync(InternetGatewayDevice internetGatewayDevice);
}
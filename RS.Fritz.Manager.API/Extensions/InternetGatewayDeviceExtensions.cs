namespace RS.Fritz.Manager.API;

public static class InternetGatewayDeviceExtensions
{
    public static Task<HostsGetHostNumberOfEntriesResponse> HostsGetHostNumberOfEntriesAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.HostsGetHostNumberOfEntriesAsync(d));
    }

    public static Task<HostsGetHostListPathResponse> HostsGetHostListPathAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.HostsGetHostListPathAsync(d));
    }

    public static Task<HostsGetGenericHostEntryResponse> HostsGetGenericHostEntryAsync(this InternetGatewayDevice internetGatewayDevice, HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.HostsGetGenericHostEntryAsync(d, hostsGetGenericHostEntryRequest));
    }

    public static Task<HostsGetChangeCounterResponse> HostsGetChangeCounterAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.HostsGetChangeCounterAsync(d));
    }

    public static Task<HostsGetMeshListPathResponse> HostsGetMeshListPathAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.HostsGetMeshListPathAsync(d));
    }

    public static Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> WanCommonInterfaceConfigGetCommonLinkPropertiesAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync(d));
    }

    public static Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> WanCommonInterfaceConfigGetTotalBytesReceivedAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalBytesReceivedAsync(d));
    }

    public static Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> WanCommonInterfaceConfigGetTotalBytesSentAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalBytesSentAsync(d));
    }

    public static Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(d));
    }

    public static Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> WanCommonInterfaceConfigGetTotalPacketsSentAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalPacketsSentAsync(d));
    }

    public static Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> WanCommonInterfaceConfigGetOnlineMonitorAsync(this InternetGatewayDevice internetGatewayDevice, WanCommonInterfaceConfigGetOnlineMonitorRequest wanCommonInterfaceConfigGetOnlineMonitorRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetOnlineMonitorAsync(d, wanCommonInterfaceConfigGetOnlineMonitorRequest));
    }

    public static Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> WanCommonInterfaceConfigSetWanAccessTypeAsync(this InternetGatewayDevice internetGatewayDevice, WanCommonInterfaceConfigSetWanAccessTypeRequest wanCommonInterfaceConfigSetWanAccessTypeRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigSetWanAccessTypeAsync(d, wanCommonInterfaceConfigSetWanAccessTypeRequest));
    }

    public static Task<DeviceInfoGetInfoResponse> DeviceInfoGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.DeviceInfoGetInfoAsync(d));
    }

    public static Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.DeviceInfoGetDeviceLogAsync(d));
    }

    public static Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.DeviceInfoGetSecurityPortAsync(d));
    }

    public static Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(this InternetGatewayDevice internetGatewayDevice, DeviceInfoSetProvisioningCodeRequest deviceInfoSetProvisioningCodeRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.DeviceInfoSetProvisioningCodeAsync(d, deviceInfoSetProvisioningCodeRequest));
    }

    public static Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanConfigSecurityGetAnonymousLoginAsync(d));
    }

    public static Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanConfigSecurityGetCurrentUserAsync(d));
    }

    public static Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanConfigSecurityGetInfoAsync(d));
    }

    public static Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanConfigSecurityGetUserListAsync(d));
    }

    public static Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(this InternetGatewayDevice internetGatewayDevice, LanConfigSecuritySetConfigPasswordRequest lanConfigSecuritySetConfigPasswordRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanConfigSecuritySetConfigPasswordAsync(d, lanConfigSecuritySetConfigPasswordRequest));
    }

    public static Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.Layer3ForwardingGetDefaultConnectionServiceAsync(d));
    }

    public static Task<Layer3ForwardingGetForwardNumberOfEntriesResponse> Layer3ForwardingGetForwardNumberOfEntriesAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.Layer3ForwardingGetForwardNumberOfEntriesAsync(d));
    }

    public static Task<Layer3ForwardingGetGenericForwardingEntryResponse> Layer3ForwardingGetGenericForwardingEntryAsync(this InternetGatewayDevice internetGatewayDevice, Layer3ForwardingGetGenericForwardingEntryRequest layer3ForwardingGetGenericForwardingEntryRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.Layer3ForwardingGetGenericForwardingEntryAsync(d, layer3ForwardingGetGenericForwardingEntryRequest));
    }

    public static Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> WanDslInterfaceConfigGetDslDiagnoseInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslInterfaceConfigGetDslDiagnoseInfoAsync(d));
    }

    public static Task<WanDslInterfaceConfigGetDslInfoResponse> WanDslInterfaceConfigGetDslInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslInterfaceConfigGetDslInfoAsync(d));
    }

    public static Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslInterfaceConfigGetInfoAsync(d));
    }

    public static Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslInterfaceConfigGetStatisticsTotalAsync(d));
    }

    public static Task<WanIpConnectionGetInfoResponse> WanIpConnectionGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetInfoAsync(d));
    }

    public static Task<WanConnectionGetConnectionTypeInfoResponse> WanIpConnectionGetConnectionTypeInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetConnectionTypeInfoAsync(d));
    }

    public static Task<WanConnectionGetStatusInfoResponse> WanIpConnectionGetStatusInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetStatusInfoAsync(d));
    }

    public static Task<WanConnectionGetNatRsipStatusResponse> WanIpConnectionGetNatRsipStatusAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetNatRsipStatusAsync(d));
    }

    public static Task<WanConnectionGetDnsServersResponse> WanIpConnectionGetDnsServersAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetDnsServersAsync(d));
    }

    public static Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanIpConnectionGetPortMappingNumberOfEntriesAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetPortMappingNumberOfEntriesAsync(d));
    }

    public static Task<WanConnectionGetExternalIpAddressResponse> WanIpConnectionGetExternalIpAddressAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetExternalIpAddressAsync(d));
    }

    public static Task<WanConnectionGetGenericPortMappingEntryResponse> WanIpConnectionGetGenericPortMappingEntryAsync(this InternetGatewayDevice internetGatewayDevice, WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetGenericPortMappingEntryAsync(d, wanConnectionGetGenericPortMappingEntryRequest));
    }

    public static Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetInfoAsync(d));
    }

    public static Task<WanConnectionGetConnectionTypeInfoResponse> WanPppConnectionGetConnectionTypeInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetConnectionTypeInfoAsync(d));
    }

    public static Task<WanConnectionGetStatusInfoResponse> WanPppConnectionGetStatusInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetStatusInfoAsync(d));
    }

    public static Task<WanPppConnectionGetLinkLayerMaxBitRatesResponse> WanPppConnectionGetLinkLayerMaxBitRatesAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetLinkLayerMaxBitRatesAsync(d));
    }

    public static Task<WanPppConnectionGetUserNameResponse> WanPppConnectionGetUserNameAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetUserNameAsync(d));
    }

    public static Task<WanConnectionGetNatRsipStatusResponse> WanPppConnectionGetNatRsipStatusAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetNatRsipStatusAsync(d));
    }

    public static Task<WanConnectionGetDnsServersResponse> WanPppConnectionGetDnsServersAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetDnsServersAsync(d));
    }

    public static Task<WanConnectionGetPortMappingNumberOfEntriesResponse> WanPppConnectionGetPortMappingNumberOfEntriesAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetPortMappingNumberOfEntriesAsync(d));
    }

    public static Task<WanConnectionGetExternalIpAddressResponse> WanPppConnectionGetExternalIpAddressAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetExternalIpAddressAsync(d));
    }

    public static Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> WanPppConnectionGetAutoDisconnectTimeSpanAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetAutoDisconnectTimeSpanAsync(d));
    }

    public static Task<WanConnectionGetGenericPortMappingEntryResponse> WanPppConnectionGetGenericPortMappingEntryAsync(this InternetGatewayDevice internetGatewayDevice, WanConnectionGetGenericPortMappingEntryRequest wanConnectionGetGenericPortMappingEntryRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetGenericPortMappingEntryAsync(d, wanConnectionGetGenericPortMappingEntryRequest));
    }

    public static Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> WanEthernetLinkConfigGetEthernetLinkStatusAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanEthernetLinkConfigGetEthernetLinkStatusAsync(d));
    }

    public static Task<WanDslLinkConfigGetInfoResponse> WanDslLinkConfigGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslLinkConfigGetInfoAsync(d));
    }

    public static Task<WanDslLinkConfigGetDslLinkInfoResponse> WanDslLinkConfigGetDslLinkInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslLinkConfigGetDslLinkInfoAsync(d));
    }

    public static Task<WanDslLinkConfigGetDestinationAddressResponse> WanDslLinkConfigGetDestinationAddressAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslLinkConfigGetDestinationAddressAsync(d));
    }

    public static Task<WanDslLinkConfigGetAtmEncapsulationResponse> WanDslLinkConfigGetAtmEncapsulationAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslLinkConfigGetAtmEncapsulationAsync(d));
    }

    public static Task<WanDslLinkConfigGetAutoConfigResponse> WanDslLinkConfigGetAutoConfigAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslLinkConfigGetAutoConfigAsync(d));
    }

    public static Task<WanDslLinkConfigGetStatisticsResponse> WanDslLinkConfigGetStatisticsAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslLinkConfigGetStatisticsAsync(d));
    }

    public static Task<AvmSpeedtestGetInfoResponse> AvmSpeedtestGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.AvmSpeedtestGetInfoAsync(d));
    }

    public static Task<LanEthernetInterfaceConfigGetInfoResponse> LanEthernetInterfaceConfigGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanEthernetInterfaceConfigGetInfoAsync(d));
    }

    public static Task<LanEthernetInterfaceConfigGetStatisticsResponse> LanEthernetInterfaceConfigGetStatisticsAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanEthernetInterfaceConfigGetStatisticsAsync(d));
    }

    public static Task<LanHostConfigManagementGetInfoResponse> LanHostConfigManagementGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanHostConfigManagementGetInfoAsync(d));
    }

    public static Task<LanHostConfigManagementGetSubnetMaskResponse> LanHostConfigManagementGetSubnetMaskAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanHostConfigManagementGetSubnetMaskAsync(d));
    }

    public static Task<LanHostConfigManagementGetIpRoutersListResponse> LanHostConfigManagementGetIpRoutersListAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanHostConfigManagementGetIpRoutersListAsync(d));
    }

    public static Task<LanHostConfigManagementGetAddressRangeResponse> LanHostConfigManagementGetAddressRangeAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanHostConfigManagementGetAddressRangeAsync(d));
    }

    public static Task<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse> LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanHostConfigManagementGetIpInterfaceNumberOfEntriesAsync(d));
    }

    public static Task<LanHostConfigManagementGetDnsServersResponse> LanHostConfigManagementGetDnsServersAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanHostConfigManagementGetDnsServersAsync(d));
    }

    public static Task<WlanConfigurationGetInfoResponse> WlanConfigurationGetInfoAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetInfoAsync(d), (h, d) => h.WlanConfiguration2GetInfoAsync(d), (h, d) => h.WlanConfiguration3GetInfoAsync(d), (h, d) => h.WlanConfiguration4GetInfoAsync(d)));
    }

    public static Task<WlanConfigurationGetWlanDeviceListPathResponse> WlanConfigurationGetWlanDeviceListPathAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetWlanDeviceListPathAsync(d), (h, d) => h.WlanConfiguration2GetWlanDeviceListPathAsync(d), (h, d) => h.WlanConfiguration3GetWlanDeviceListPathAsync(d), (h, d) => h.WlanConfiguration4GetWlanDeviceListPathAsync(d)));
    }

    public static Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> WlanConfigurationGetBasBeaconSecurityPropertiesAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetBasBeaconSecurityPropertiesAsync(d), (h, d) => h.WlanConfiguration2GetBasBeaconSecurityPropertiesAsync(d), (h, d) => h.WlanConfiguration3GetBasBeaconSecurityPropertiesAsync(d), (h, d) => h.WlanConfiguration4GetBasBeaconSecurityPropertiesAsync(d)));
    }

    public static Task<WlanConfigurationGetBssIdResponse> WlanConfigurationGetBssIdAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetBssIdAsync(d), (h, d) => h.WlanConfiguration2GetBssIdAsync(d), (h, d) => h.WlanConfiguration3GetBssIdAsync(d), (h, d) => h.WlanConfiguration4GetBssIdAsync(d)));
    }

    public static Task<WlanConfigurationGetSsIdResponse> WlanConfigurationGetSsIdAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetSsIdAsync(d), (h, d) => h.WlanConfiguration2GetSsIdAsync(d), (h, d) => h.WlanConfiguration3GetSsIdAsync(d), (h, d) => h.WlanConfiguration4GetSsIdAsync(d)));
    }

    public static Task<WlanConfigurationGetBeaconTypeResponse> WlanConfigurationGetBeaconTypeAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetBeaconTypeAsync(d), (h, d) => h.WlanConfiguration2GetBeaconTypeAsync(d), (h, d) => h.WlanConfiguration3GetBeaconTypeAsync(d), (h, d) => h.WlanConfiguration4GetBeaconTypeAsync(d)));
    }

    public static Task<WlanConfigurationGetChannelInfoResponse> WlanConfigurationGetChannelInfoAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetChannelInfoAsync(d), (h, d) => h.WlanConfiguration2GetChannelInfoAsync(d), (h, d) => h.WlanConfiguration3GetChannelInfoAsync(d), (h, d) => h.WlanConfiguration4GetChannelInfoAsync(d)));
    }

    public static Task<WlanConfigurationGetBeaconAdvertisementResponse> WlanConfigurationGetBeaconAdvertisementAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetBeaconAdvertisementAsync(d), (h, d) => h.WlanConfiguration2GetBeaconAdvertisementAsync(d), (h, d) => h.WlanConfiguration3GetBeaconAdvertisementAsync(d), (h, d) => h.WlanConfiguration4GetBeaconAdvertisementAsync(d)));
    }

    public static Task<WlanConfigurationGetTotalAssociationsResponse> WlanConfigurationGetTotalAssociationsAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetTotalAssociationsAsync(d), (h, d) => h.WlanConfiguration2GetTotalAssociationsAsync(d), (h, d) => h.WlanConfiguration3GetTotalAssociationsAsync(d), (h, d) => h.WlanConfiguration4GetTotalAssociationsAsync(d)));
    }

    public static Task<WlanConfigurationGetIpTvOptimizedResponse> WlanConfigurationGetIpTvOptimizedAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetIpTvOptimizedAsync(d), (h, d) => h.WlanConfiguration2GetIpTvOptimizedAsync(d), (h, d) => h.WlanConfiguration3GetIpTvOptimizedAsync(d), (h, d) => h.WlanConfiguration4GetIpTvOptimizedAsync(d)));
    }

    public static Task<WlanConfigurationGetStatisticsResponse> WlanConfigurationGetStatisticsAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetStatisticsAsync(d), (h, d) => h.WlanConfiguration2GetStatisticsAsync(d), (h, d) => h.WlanConfiguration3GetStatisticsAsync(d), (h, d) => h.WlanConfiguration4GetStatisticsAsync(d)));
    }

    public static Task<WlanConfigurationGetPacketStatisticsResponse> WlanConfigurationGetPacketStatisticsAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetPacketStatisticsAsync(d), (h, d) => h.WlanConfiguration2GetPacketStatisticsAsync(d), (h, d) => h.WlanConfiguration3GetPacketStatisticsAsync(d), (h, d) => h.WlanConfiguration4GetPacketStatisticsAsync(d)));
    }

    public static Task<WlanConfigurationGetNightControlResponse> WlanConfigurationGetNightControlAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetNightControlAsync(d), (h, d) => h.WlanConfiguration2GetNightControlAsync(d), (h, d) => h.WlanConfiguration3GetNightControlAsync(d), (h, d) => h.WlanConfiguration4GetNightControlAsync(d)));
    }

    public static Task<WlanConfigurationGetWlanHybridModeResponse> WlanConfigurationGetWlanHybridModeAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetWlanHybridModeAsync(d), (h, d) => h.WlanConfiguration2GetWlanHybridModeAsync(d), (h, d) => h.WlanConfiguration3GetWlanHybridModeAsync(d), (h, d) => h.WlanConfiguration4GetWlanHybridModeAsync(d)));
    }

    public static Task<WlanConfigurationGetWlanExtInfoResponse> WlanConfigurationGetWlanExtInfoAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetWlanExtInfoAsync(d), (h, d) => h.WlanConfiguration2GetWlanExtInfoAsync(d), (h, d) => h.WlanConfiguration3GetWlanExtInfoAsync(d), (h, d) => h.WlanConfiguration4GetWlanExtInfoAsync(d)));
    }

    public static Task<WlanConfigurationGetWpsInfoResponse> WlanConfigurationGetWpsInfoAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetWpsInfoAsync(d), (h, d) => h.WlanConfiguration2GetWpsInfoAsync(d), (h, d) => h.WlanConfiguration3GetWpsInfoAsync(d), (h, d) => h.WlanConfiguration4GetWpsInfoAsync(d)));
    }

    public static Task<WlanConfigurationGetWlanConnectionInfoResponse> WlanConfigurationGetWlanConnectionInfoAsync(this InternetGatewayDevice internetGatewayDevice, int interfaceNumber)
    {
        return internetGatewayDevice.ExecuteAsync(GetWlanOperation(interfaceNumber, (h, d) => h.WlanConfiguration1GetWlanConnectionInfoAsync(d), (h, d) => h.WlanConfiguration2GetWlanConnectionInfoAsync(d), (h, d) => h.WlanConfiguration3GetWlanConnectionInfoAsync(d), (h, d) => h.WlanConfiguration4GetWlanConnectionInfoAsync(d)));
    }

    public static Task<ManagementServerGetInfoResponse> ManagementServerGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerGetInfoAsync(d));
    }

    public static Task<ManagementServerGetTr069FirmwareDownloadEnabledResponse> ManagementServerGetTr069FirmwareDownloadEnabledAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerGetTr069FirmwareDownloadEnabledAsync(d));
    }

    public static Task<ManagementServerSetManagementServerUrlResponse> ManagementServerSetManagementServerUrlAsync(this InternetGatewayDevice internetGatewayDevice, ManagementServerSetManagementServerUrlRequest managementServerSetManagementServerUrlRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerSetManagementServerUrlAsync(d, managementServerSetManagementServerUrlRequest));
    }

    public static Task<ManagementServerSetManagementServerUsernameResponse> ManagementServerSetManagementServerUsernameAsync(this InternetGatewayDevice internetGatewayDevice, ManagementServerSetManagementServerUsernameRequest managementServerSetManagementServerUsernameRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerSetManagementServerUsernameAsync(d, managementServerSetManagementServerUsernameRequest));
    }

    public static Task<ManagementServerSetManagementServerPasswordResponse> ManagementServerSetManagementServerPasswordAsync(this InternetGatewayDevice internetGatewayDevice, ManagementServerSetManagementServerPasswordRequest managementServerSetManagementServerPasswordRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerSetManagementServerPasswordAsync(d, managementServerSetManagementServerPasswordRequest));
    }

    public static Task<ManagementServerSetPeriodicInformResponse> ManagementServerSetPeriodicInformAsync(this InternetGatewayDevice internetGatewayDevice, ManagementServerSetPeriodicInformRequest managementServerSetPeriodicInformRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerSetPeriodicInformAsync(d, managementServerSetPeriodicInformRequest));
    }

    public static Task<ManagementServerSetConnectionRequestAuthenticationResponse> ManagementServerSetConnectionRequestAuthenticationAsync(this InternetGatewayDevice internetGatewayDevice, ManagementServerSetConnectionRequestAuthenticationRequest managementServerSetConnectionRequestAuthenticationRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerSetConnectionRequestAuthenticationAsync(d, managementServerSetConnectionRequestAuthenticationRequest));
    }

    public static Task<ManagementServerSetUpgradeManagementResponse> ManagementServerSetUpgradeManagementAsync(this InternetGatewayDevice internetGatewayDevice, ManagementServerSetUpgradeManagementRequest managementServerSetUpgradeManagementRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerSetUpgradeManagementAsync(d, managementServerSetUpgradeManagementRequest));
    }

    public static Task<ManagementServerSetTr069EnableResponse> ManagementServerSetTr069EnableAsync(this InternetGatewayDevice internetGatewayDevice, ManagementServerSetTr069EnableRequest managementServerSetTr069EnableRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerSetTr069EnableAsync(d, managementServerSetTr069EnableRequest));
    }

    public static Task<ManagementServerSetTr069FirmwareDownloadEnabledResponse> ManagementServerSetTr069FirmwareDownloadEnabledAsync(this InternetGatewayDevice internetGatewayDevice, ManagementServerSetTr069FirmwareDownloadEnabledRequest managementServerSetTr069FirmwareDownloadEnabledRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.ManagementServerSetTr069FirmwareDownloadEnabledAsync(d, managementServerSetTr069FirmwareDownloadEnabledRequest));
    }

    public static Task<TimeGetInfoResponse> TimeGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.TimeGetInfoAsync(d));
    }

    public static Task<TimeSetNtpServersResponse> TimeSetNtpServersAsync(this InternetGatewayDevice internetGatewayDevice, TimeSetNtpServersRequest timeSetNtpServersRequest)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.TimeSetNtpServersAsync(d, timeSetNtpServersRequest));
    }

    private static Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<T>> GetWlanOperation<T>(
        int interfaceNumber,
        Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<T>> interface1Operation,
        Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<T>> interface2Operation,
        Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<T>> interface3Operation,
        Func<IFritzServiceOperationHandler, InternetGatewayDevice, Task<T>> interface4Operation)
    {
        return interfaceNumber switch
        {
            1 => interface1Operation,
            2 => interface2Operation,
            3 => interface3Operation,
            4 => interface4Operation,
            _ => throw new ArgumentOutOfRangeException(nameof(interfaceNumber), interfaceNumber, null)
        };
    }
}
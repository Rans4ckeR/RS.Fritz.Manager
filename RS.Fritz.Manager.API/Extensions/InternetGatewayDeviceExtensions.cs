namespace RS.Fritz.Manager.API;

using System.Threading.Tasks;

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

    public static Task<HostsGetGenericHostEntryResponse> HostsGetGenericHostEntryAsync(this InternetGatewayDevice internetGatewayDevice, ushort index)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.HostsGetGenericHostEntryAsync(d, index));
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

    public static Task<WanCommonInterfaceConfigGetOnlineMonitorResponse> WanCommonInterfaceConfigGetOnlineMonitorAsync(this InternetGatewayDevice internetGatewayDevice, uint syncGroupIndex)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetOnlineMonitorAsync(d, syncGroupIndex));
    }

    public static Task<WanCommonInterfaceConfigSetWanAccessTypeResponse> WanCommonInterfaceConfigSetWanAccessTypeAsync(this InternetGatewayDevice internetGatewayDevice, string accessType)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigSetWanAccessTypeAsync(d, accessType));
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

    public static Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(this InternetGatewayDevice internetGatewayDevice, string provisioningCode)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.DeviceInfoSetProvisioningCodeAsync(d, provisioningCode));
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

    public static Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(this InternetGatewayDevice internetGatewayDevice, string password)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.LanConfigSecuritySetConfigPasswordAsync(d, password));
    }

    public static Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.Layer3ForwardingGetDefaultConnectionServiceAsync(d));
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

    public static Task<WanIpConnectionGetConnectionTypeInfoResponse> WanIpConnectionGetConnectionTypeInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetConnectionTypeInfoAsync(d));
    }

    public static Task<WanIpConnectionGetStatusInfoResponse> WanIpConnectionGetStatusInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetStatusInfoAsync(d));
    }

    public static Task<WanIpConnectionGetNatRsipStatusResponse> WanIpConnectionGetNatRsipStatusAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetNatRsipStatusAsync(d));
    }

    public static Task<WanIpConnectionGetDnsServersResponse> WanIpConnectionGetDnsServersAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetDnsServersAsync(d));
    }

    public static Task<WanIpConnectionGetPortMappingNumberOfEntriesResponse> WanIpConnectionGetPortMappingNumberOfEntriesAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetPortMappingNumberOfEntriesAsync(d));
    }

    public static Task<WanIpConnectionGetExternalIpAddressResponse> WanIpConnectionGetExternalIpAddressAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanIpConnectionGetExternalIpAddressAsync(d));
    }

    public static Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetInfoAsync(d));
    }

    public static Task<WanPppConnectionGetConnectionTypeInfoResponse> WanPppConnectionGetConnectionTypeInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetConnectionTypeInfoAsync(d));
    }

    public static Task<WanPppConnectionGetStatusInfoResponse> WanPppConnectionGetStatusInfoAsync(this InternetGatewayDevice internetGatewayDevice)
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

    public static Task<WanPppConnectionGetNatRsipStatusResponse> WanPppConnectionGetNatRsipStatusAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetNatRsipStatusAsync(d));
    }

    public static Task<WanPppConnectionGetDnsServersResponse> WanPppConnectionGetDnsServersAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetDnsServersAsync(d));
    }

    public static Task<WanPppConnectionGetPortMappingNumberOfEntriesResponse> WanPppConnectionGetPortMappingNumberOfEntriesAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetPortMappingNumberOfEntriesAsync(d));
    }

    public static Task<WanPppConnectionGetExternalIpAddressResponse> WanPppConnectionGetExternalIpAddressAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetExternalIpAddressAsync(d));
    }

    public static Task<WanPppConnectionGetAutoDisconnectTimeSpanResponse> WanPppConnectionGetAutoDisconnectTimeSpanAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanPppConnectionGetAutoDisconnectTimeSpanAsync(d));
    }

    public static Task<WanEthernetLinkConfigGetEthernetLinkStatusResponse> WanEthernetLinkConfigGetEthernetLinkStatusAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanEthernetLinkConfigGetEthernetLinkStatusAsync(d));
    }

    public static Task<WanDslLinkConfigGetInfoResponse> WanDslLinkConfigGetInfoAsync(this InternetGatewayDevice internetGatewayDevice)
    {
        return internetGatewayDevice.ExecuteAsync((h, d) => h.WanDslLinkConfigGetInfoAsync(d));
    }
}
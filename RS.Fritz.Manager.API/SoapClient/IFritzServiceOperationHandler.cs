namespace RS.Fritz.Manager.API;

using System.Threading.Tasks;

public interface IFritzServiceOperationHandler
{
    Task<HostsGetHostNumberOfEntriesResponse> GetHostsGetHostNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice);

    Task<HostsGetHostListPathResponse> GetHostsGetHostListPathAsync(InternetGatewayDevice internetGatewayDevice);

    Task<HostsGetGenericHostEntryResponse> GetHostsGetGenericHostEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort index);

    Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> GetWanCommonInterfaceConfigGetTotalBytesSentAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync(InternetGatewayDevice internetGatewayDevice);

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

    Task<WanDslInterfaceConfigGetDSLDiagnoseInfoResponse> WanDslInterfaceConfigGetDSLDiagnoseInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslInterfaceConfigGetDSLInfoResponse> WanDslInterfaceConfigGetDSLInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice);

    Task<WanIpConnectionGetInfoResponse> WanIpConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice);
}
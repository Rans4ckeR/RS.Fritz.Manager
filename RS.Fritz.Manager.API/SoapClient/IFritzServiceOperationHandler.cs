namespace RS.Fritz.Manager.API
{
    using System.Net;
    using System.Threading.Tasks;

    public interface IFritzServiceOperationHandler
    {
        InternetGatewayDevice? InternetGatewayDevice { get; set; }

        NetworkCredential? NetworkCredential { get; set; }

        Task<HostsGetHostNumberOfEntriesResponse> GetHostsGetHostNumberOfEntriesAsync();

        Task<HostsGetHostListPathResponse> GetHostsGetHostListPathAsync();

        Task<HostsGetGenericHostEntryResponse> GetHostsGetGenericHostEntryAsync(ushort index);

        Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync();

        Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> GetWanCommonInterfaceConfigGetTotalBytesSentAsync();

        Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync();

        Task<DeviceInfoGetInfoResponse> DeviceInfoGetInfoAsync();

        Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync();

        Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync();

        Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(string provisioningCode);

        Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync();

        Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync();

        Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync();

        Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync();

        Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(string password);

        Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync();

        Task<WanDslInterfaceConfigGetDSLDiagnoseInfoResponse> WanDslInterfaceConfigGetDSLDiagnoseInfoAsync();

        Task<WanDslInterfaceConfigGetDSLInfoResponse> WanDslInterfaceConfigGetDSLInfoAsync();

        Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync();

        Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync();

        Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync();
    }
}
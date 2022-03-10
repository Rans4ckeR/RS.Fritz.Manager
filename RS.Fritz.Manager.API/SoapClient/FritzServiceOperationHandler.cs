namespace RS.Fritz.Manager.API;

using System.Threading.Tasks;

internal sealed class FritzServiceOperationHandler : ServiceOperationHandler, IFritzServiceOperationHandler
{
    private readonly IClientFactory<IFritzHostsService> fritzHostsServiceClientFactory;
    private readonly IClientFactory<IFritzWanCommonInterfaceConfigService> fritzWanCommonInterfaceConfigServiceClientFactory;
    private readonly IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory;
    private readonly IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory;
    private readonly IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory;
    private readonly IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory;
    private readonly IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory;
    private readonly IClientFactory<IFritzWanIpConnectionService> fritzWanIpConnectionServiceClientFactory;

    public FritzServiceOperationHandler(
        IClientFactory<IFritzHostsService> fritzHostsServiceClientFactory,
        IClientFactory<IFritzWanCommonInterfaceConfigService> fritzWanCommonInterfaceConfigServiceClientFactory,
        IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory,
        IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory,
        IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory,
        IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory,
        IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory,
        IClientFactory<IFritzWanIpConnectionService> fritzWanIpConnectionServiceClientFactory)
    {
        this.fritzHostsServiceClientFactory = fritzHostsServiceClientFactory;
        this.fritzWanCommonInterfaceConfigServiceClientFactory = fritzWanCommonInterfaceConfigServiceClientFactory;
        this.fritzDeviceInfoServiceClientFactory = fritzDeviceInfoServiceClientFactory;
        this.fritzLanConfigSecurityServiceClientFactory = fritzLanConfigSecurityServiceClientFactory;
        this.fritzLayer3ForwardingServiceClientFactory = fritzLayer3ForwardingServiceClientFactory;
        this.fritzWanDslInterfaceConfigServiceClientFactory = fritzWanDslInterfaceConfigServiceClientFactory;
        this.fritzWanPppConnectionServiceClientFactory = fritzWanPppConnectionServiceClientFactory;
        this.fritzWanIpConnectionServiceClientFactory = fritzWanIpConnectionServiceClientFactory;
    }

    public Task<HostsGetHostNumberOfEntriesResponse> GetHostsGetHostNumberOfEntriesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzHostsServiceClient(internetGatewayDevice), q => q.GetHostNumberOfEntriesAsync(new HostsGetHostNumberOfEntriesRequest()));
    }

    public Task<HostsGetHostListPathResponse> GetHostsGetHostListPathAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzHostsServiceClient(internetGatewayDevice), q => q.GetHostListPathAsync(new HostsGetHostListPathRequest()));
    }

    public Task<HostsGetGenericHostEntryResponse> GetHostsGetGenericHostEntryAsync(InternetGatewayDevice internetGatewayDevice, ushort index)
    {
        return ExecuteAsync(GetFritzHostsServiceClient(internetGatewayDevice), q => q.GetGenericHostEntryAsync(new HostsGetGenericHostEntryRequest { Index = index }));
    }

    public Task<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse> GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanCommonInterfaceConfigServiceClient(internetGatewayDevice), q => q.GetCommonLinkPropertiesAsync(new WanCommonInterfaceConfigGetCommonLinkPropertiesRequest()));
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanCommonInterfaceConfigServiceClient(internetGatewayDevice), q => q.GetTotalBytesReceivedAsync(new WanCommonInterfaceConfigGetTotalBytesReceivedRequest()));
    }

    public Task<WanCommonInterfaceConfigGetTotalBytesSentResponse> GetWanCommonInterfaceConfigGetTotalBytesSentAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanCommonInterfaceConfigServiceClient(internetGatewayDevice), q => q.GetTotalBytesSentAsync(new WanCommonInterfaceConfigGetTotalBytesSentRequest()));
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse> GetWanCommonInterfaceConfigGetTotalPacketsReceivedAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanCommonInterfaceConfigServiceClient(internetGatewayDevice), q => q.GetTotalPacketsReceivedAsync(new WanCommonInterfaceConfigGetTotalPacketsReceivedRequest()));
    }

    public Task<WanCommonInterfaceConfigGetTotalPacketsSentResponse> GetWanCommonInterfaceConfigGetTotalPacketsSentAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanCommonInterfaceConfigServiceClient(internetGatewayDevice), q => q.GetTotalPacketsSentAsync(new WanCommonInterfaceConfigGetTotalPacketsSentRequest()));
    }

    public Task<DeviceInfoGetInfoResponse> DeviceInfoGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzDeviceInfoServiceClient(internetGatewayDevice, true), q => q.GetInfoAsync(new DeviceInfoGetInfoRequest()));
    }

    public Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzDeviceInfoServiceClient(internetGatewayDevice, true), q => q.GetDeviceLogAsync(new DeviceInfoGetDeviceLogRequest()));
    }

    public Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzDeviceInfoServiceClient(internetGatewayDevice), q => q.GetSecurityPortAsync(new DeviceInfoGetSecurityPortRequest()));
    }

    public Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(InternetGatewayDevice internetGatewayDevice, string provisioningCode)
    {
        return ExecuteAsync(GetFritzDeviceInfoServiceClient(internetGatewayDevice, true), q => q.SetProvisioningCodeAsync(new DeviceInfoSetProvisioningCodeRequest { ProvisioningCode = provisioningCode }));
    }

    public Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(internetGatewayDevice), q => q.GetAnonymousLoginAsync(new LanConfigSecurityGetAnonymousLoginRequest()));
    }

    public Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(internetGatewayDevice), q => q.GetCurrentUserAsync(new LanConfigSecurityGetCurrentUserRequest()));
    }

    public Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(internetGatewayDevice), q => q.GetInfoAsync(new LanConfigSecurityGetInfoRequest()));
    }

    public Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(internetGatewayDevice), q => q.GetUserListAsync(new LanConfigSecurityGetUserListRequest()));
    }

    public Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(InternetGatewayDevice internetGatewayDevice, string password)
    {
        return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(internetGatewayDevice), q => q.SetConfigPasswordAsync(new LanConfigSecuritySetConfigPasswordRequest { Password = password }));
    }

    public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzLayer3ForwardingServiceClient(internetGatewayDevice), q => q.GetDefaultConnectionServiceAsync(new Layer3ForwardingGetDefaultConnectionServiceRequest()));
    }

    public Task<WanDslInterfaceConfigGetDSLDiagnoseInfoResponse> WanDslInterfaceConfigGetDSLDiagnoseInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(internetGatewayDevice), q => q.GetDSLDiagnoseInfoAsync(new WanDslInterfaceConfigGetDSLDiagnoseInfoRequest()));
    }

    public Task<WanDslInterfaceConfigGetDSLInfoResponse> WanDslInterfaceConfigGetDSLInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(internetGatewayDevice), q => q.GetDSLInfoAsync(new WanDslInterfaceConfigGetDSLInfoRequest()));
    }

    public Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(internetGatewayDevice), q => q.GetInfoAsync(new WanDslInterfaceConfigGetInfoRequest()));
    }

    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(internetGatewayDevice), q => q.GetStatisticsTotalAsync(new WanDslInterfaceConfigGetStatisticsTotalRequest()));
    }

    public Task<WanIpConnectionGetInfoResponse> WanIpConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanIpConnectionServiceClient(internetGatewayDevice), q => q.GetInfoAsync(new WanIpConnectionGetInfoRequest()));
    }

    public Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync(InternetGatewayDevice internetGatewayDevice)
    {
        return ExecuteAsync(GetFritzWanPppConnectionServiceClient(internetGatewayDevice), q => q.GetInfoAsync(new WanPppConnectionGetInfoRequest()));
    }

    private IFritzHostsService GetFritzHostsServiceClient(InternetGatewayDevice internetGatewayDevice)
    {
        return fritzHostsServiceClientFactory.Build((q, r, t) => new FritzHostsService(q, r, t!), internetGatewayDevice.PreferredLocation, true, FritzHostsService.ControlUrl, internetGatewayDevice.SecurityPort, internetGatewayDevice.NetworkCredential);
    }

    private IFritzWanCommonInterfaceConfigService GetFritzWanCommonInterfaceConfigServiceClient(InternetGatewayDevice internetGatewayDevice)
    {
        return fritzWanCommonInterfaceConfigServiceClientFactory.Build((q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), internetGatewayDevice.PreferredLocation, true, FritzWanCommonInterfaceConfigService.ControlUrl, internetGatewayDevice.SecurityPort, internetGatewayDevice.NetworkCredential);
    }

    private IFritzLanConfigSecurityService GetFritzLanConfigSecurityServiceClient(InternetGatewayDevice internetGatewayDevice)
    {
        return fritzLanConfigSecurityServiceClientFactory.Build((q, r, t) => new FritzLanConfigSecurityService(q, r, t), internetGatewayDevice.PreferredLocation, true, FritzLanConfigSecurityService.ControlUrl, internetGatewayDevice.SecurityPort, internetGatewayDevice.NetworkCredential);
    }

    private IFritzDeviceInfoService GetFritzDeviceInfoServiceClient(InternetGatewayDevice internetGatewayDevice, bool secure = false)
    {
        return fritzDeviceInfoServiceClientFactory.Build((q, r, t) => new FritzDeviceInfoService(q, r, t), internetGatewayDevice.PreferredLocation, secure, FritzDeviceInfoService.ControlUrl, secure ? internetGatewayDevice.SecurityPort : null, secure ? internetGatewayDevice.NetworkCredential : null);
    }

    private IFritzLayer3ForwardingService GetFritzLayer3ForwardingServiceClient(InternetGatewayDevice internetGatewayDevice)
    {
        return fritzLayer3ForwardingServiceClientFactory.Build((q, r, t) => new FritzLayer3ForwardingService(q, r, t!), internetGatewayDevice.PreferredLocation, true, FritzLayer3ForwardingService.ControlUrl, internetGatewayDevice.SecurityPort, internetGatewayDevice.NetworkCredential);
    }

    private IFritzWanDslInterfaceConfigService GetFritzWanDslInterfaceConfigServiceClient(InternetGatewayDevice internetGatewayDevice)
    {
        return fritzWanDslInterfaceConfigServiceClientFactory.Build((q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), internetGatewayDevice.PreferredLocation, true, FritzWanDslInterfaceConfigService.ControlUrl, internetGatewayDevice.SecurityPort, internetGatewayDevice.NetworkCredential);
    }

    private IFritzWanIpConnectionService GetFritzWanIpConnectionServiceClient(InternetGatewayDevice internetGatewayDevice)
    {
        return fritzWanIpConnectionServiceClientFactory.Build((q, r, t) => new FritzWanIpConnectionService(q, r, t!), internetGatewayDevice.PreferredLocation, true, FritzWanIpConnectionService.ControlUrl, internetGatewayDevice.SecurityPort, internetGatewayDevice.NetworkCredential);
    }

    private IFritzWanPppConnectionService GetFritzWanPppConnectionServiceClient(InternetGatewayDevice internetGatewayDevice)
    {
        return fritzWanPppConnectionServiceClientFactory.Build((q, r, t) => new FritzWanPppConnectionService(q, r, t!), internetGatewayDevice.PreferredLocation, true, FritzWanPppConnectionService.ControlUrl, internetGatewayDevice.SecurityPort, internetGatewayDevice.NetworkCredential);
    }
}
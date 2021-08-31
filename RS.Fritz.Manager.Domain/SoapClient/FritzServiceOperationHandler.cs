namespace RS.Fritz.Manager.Domain
{
    using System.Net;
    using System.Threading.Tasks;

    public sealed class FritzServiceOperationHandler : IFritzServiceOperationHandler
    {
        private readonly IServiceOperationHandler serviceOperationHandler;
        private readonly IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory;
        private readonly IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory;
        private readonly IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory;
        private readonly IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory;
        private readonly IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory;

        public FritzServiceOperationHandler(
            IServiceOperationHandler serviceOperationHandler,
            IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory,
            IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory,
            IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory,
            IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory,
            IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory)
        {
            this.serviceOperationHandler = serviceOperationHandler;
            this.fritzDeviceInfoServiceClientFactory = fritzDeviceInfoServiceClientFactory;
            this.fritzLanConfigSecurityServiceClientFactory = fritzLanConfigSecurityServiceClientFactory;
            this.fritzLayer3ForwardingServiceClientFactory = fritzLayer3ForwardingServiceClientFactory;
            this.fritzWanDslInterfaceConfigServiceClientFactory = fritzWanDslInterfaceConfigServiceClientFactory;
            this.fritzWanPppConnectionServiceClientFactory = fritzWanPppConnectionServiceClientFactory;
        }

        public InternetGatewayDevice? InternetGatewayDevice { get; set; }

        public NetworkCredential? NetworkCredential { get; set; }

        public Task<DeviceInfoGetInfoResponse> DeviceInfoGetInfoAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(true, InternetGatewayDevice!.SecurityPort, NetworkCredential), q => q.GetInfoAsync(new DeviceInfoGetInfoRequest()));
        }

        public Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(true, InternetGatewayDevice!.SecurityPort, NetworkCredential), q => q.GetDeviceLogAsync(new DeviceInfoGetDeviceLogRequest()));
        }

        public Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(), q => q.GetSecurityPortAsync(new DeviceInfoGetSecurityPortRequest()));
        }

        public Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(string provisioningCode)
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(true, InternetGatewayDevice!.SecurityPort, NetworkCredential), q => q.SetProvisioningCodeAsync(new DeviceInfoSetProvisioningCodeRequest { ProvisioningCode = provisioningCode }));
        }

        public Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.GetAnonymousLoginAsync(new LanConfigSecurityGetAnonymousLoginRequest()));
        }

        public Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.GetCurrentUserAsync(new LanConfigSecurityGetCurrentUserRequest()));
        }

        public Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.GetInfoAsync(new LanConfigSecurityGetInfoRequest()));
        }

        public Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.GetUserListAsync(new LanConfigSecurityGetUserListRequest()));
        }

        public Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(string password)
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.SetConfigPasswordAsync(new LanConfigSecuritySetConfigPasswordRequest { Password = password }));
        }

        public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzLayer3ForwardingServiceClient(), q => q.GetDefaultConnectionServiceAsync(new Layer3ForwardingGetDefaultConnectionServiceRequest()));
        }

        public Task<WanDslInterfaceConfigGetDSLDiagnoseInfoResponse> WanDslInterfaceConfigGetDSLDiagnoseInfoAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(), q => q.GetDSLDiagnoseInfoAsync(new WanDslInterfaceConfigGetDSLDiagnoseInfoRequest()));
        }

        public Task<WanDslInterfaceConfigGetDSLInfoResponse> WanDslInterfaceConfigGetDSLInfoAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(), q => q.GetDSLInfoAsync(new WanDslInterfaceConfigGetDSLInfoRequest()));
        }

        public Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(), q => q.GetInfoAsync(new WanDslInterfaceConfigGetInfoRequest()));
        }

        public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(), q => q.GetStatisticsTotalAsync(new WanDslInterfaceConfigGetStatisticsTotalRequest()));
        }

        public Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync()
        {
            return serviceOperationHandler.ExecuteAsync(GetFritzWanPppConnectionServiceClient(), q => q.GetInfoAsync(new WanPppConnectionGetInfoRequest()));
        }

        private IFritzLanConfigSecurityService GetFritzLanConfigSecurityServiceClient()
        {
            return fritzLanConfigSecurityServiceClientFactory.Build((q, r, t) => new FritzLanConfigSecurityService(q, r, t), InternetGatewayDevice!.PreferredLocation!, true, FritzLanConfigSecurityService.ControlUrl, InternetGatewayDevice!.SecurityPort, NetworkCredential);
        }

        private IFritzDeviceInfoService GetFritzDeviceInfoServiceClient(bool secure = false, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return fritzDeviceInfoServiceClientFactory.Build((q, r, t) => new FritzDeviceInfoService(q, r, t), InternetGatewayDevice!.PreferredLocation!, secure, FritzDeviceInfoService.ControlUrl, port, networkCredential);
        }

        private IFritzLayer3ForwardingService GetFritzLayer3ForwardingServiceClient()
        {
            return fritzLayer3ForwardingServiceClientFactory.Build((q, r, t) => new FritzLayer3ForwardingService(q, r, t!), InternetGatewayDevice!.PreferredLocation!, true, FritzLayer3ForwardingService.ControlUrl, InternetGatewayDevice!.SecurityPort, NetworkCredential);
        }

        private IFritzWanDslInterfaceConfigService GetFritzWanDslInterfaceConfigServiceClient()
        {
            return fritzWanDslInterfaceConfigServiceClientFactory.Build((q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), InternetGatewayDevice!.PreferredLocation!, true, FritzWanDslInterfaceConfigService.ControlUrl, InternetGatewayDevice!.SecurityPort, NetworkCredential);
        }

        private IFritzWanPppConnectionService GetFritzWanPppConnectionServiceClient()
        {
            return fritzWanPppConnectionServiceClientFactory.Build((q, r, t) => new FritzWanPppConnectionService(q, r, t!), InternetGatewayDevice!.PreferredLocation!, true, FritzWanPppConnectionService.ControlUrl, InternetGatewayDevice!.SecurityPort, NetworkCredential);
        }
    }
}
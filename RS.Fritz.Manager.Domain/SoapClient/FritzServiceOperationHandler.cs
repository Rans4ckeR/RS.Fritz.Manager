namespace RS.Fritz.Manager.Domain
{
    using System.Net;
    using System.Threading.Tasks;

    public sealed class FritzServiceOperationHandler : ServiceOperationHandler, IFritzServiceOperationHandler
    {
        // RoSchmi
        // The local variables

        private readonly IClientFactory<IFritzWanCommonInterfaceConfigService> fritzWanCommonInterfaceConfigServiceClientFactory;
        private readonly IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory;
        private readonly IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory;
        private readonly IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory;
        private readonly IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory;
        private readonly IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory;


        // RoSchmi
        // Constructor
        public FritzServiceOperationHandler(
            IClientFactory<IFritzWanCommonInterfaceConfigService> fritzWanCommonInterfaceConfigServiceClientFactory,
            IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory,
            IClientFactory<IFritzLanConfigSecurityService> fritzLanConfigSecurityServiceClientFactory,
            IClientFactory<IFritzLayer3ForwardingService> fritzLayer3ForwardingServiceClientFactory,
            IClientFactory<IFritzWanDslInterfaceConfigService> fritzWanDslInterfaceConfigServiceClientFactory,
            IClientFactory<IFritzWanPppConnectionService> fritzWanPppConnectionServiceClientFactory)
        {
            this.fritzWanCommonInterfaceConfigServiceClientFactory = fritzWanCommonInterfaceConfigServiceClientFactory;
            this.fritzDeviceInfoServiceClientFactory = fritzDeviceInfoServiceClientFactory;
            this.fritzLanConfigSecurityServiceClientFactory = fritzLanConfigSecurityServiceClientFactory;
            this.fritzLayer3ForwardingServiceClientFactory = fritzLayer3ForwardingServiceClientFactory;
            this.fritzWanDslInterfaceConfigServiceClientFactory = fritzWanDslInterfaceConfigServiceClientFactory;
            this.fritzWanPppConnectionServiceClientFactory = fritzWanPppConnectionServiceClientFactory;
        }

        public InternetGatewayDevice? InternetGatewayDevice { get; set; }

        public NetworkCredential? NetworkCredential { get; set; }

        // RoSchmi
        public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync()
        {
            return null;
           
            return ExecuteAsync(GetFritzWanCommonInterfaceConfigServiceClient(true, InternetGatewayDevice!.SecurityPort, NetworkCredential), q => q.GetTotalBytesReceivedAsync(new WanCommonInterfaceConfigGetTotalBytesReceivedRequest()));

         }


        public Task<DeviceInfoGetInfoResponse> DeviceInfoGetInfoAsync()
        {
            return ExecuteAsync(GetFritzDeviceInfoServiceClient(true, InternetGatewayDevice!.SecurityPort, NetworkCredential), q => q.GetInfoAsync(new DeviceInfoGetInfoRequest()));
        }

        public Task<DeviceInfoGetDeviceLogResponse> DeviceInfoGetDeviceLogAsync()
        {
            return ExecuteAsync(GetFritzDeviceInfoServiceClient(true, InternetGatewayDevice!.SecurityPort, NetworkCredential), q => q.GetDeviceLogAsync(new DeviceInfoGetDeviceLogRequest()));
        }

        public Task<DeviceInfoGetSecurityPortResponse> DeviceInfoGetSecurityPortAsync()
        {
            return ExecuteAsync(GetFritzDeviceInfoServiceClient(), q => q.GetSecurityPortAsync(new DeviceInfoGetSecurityPortRequest()));
        }

        public Task<DeviceInfoSetProvisioningCodeResponse> DeviceInfoSetProvisioningCodeAsync(string provisioningCode)
        {
            return ExecuteAsync(GetFritzDeviceInfoServiceClient(true, InternetGatewayDevice!.SecurityPort, NetworkCredential), q => q.SetProvisioningCodeAsync(new DeviceInfoSetProvisioningCodeRequest { ProvisioningCode = provisioningCode }));
        }

        public Task<LanConfigSecurityGetAnonymousLoginResponse> LanConfigSecurityGetAnonymousLoginAsync()
        {
            return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.GetAnonymousLoginAsync(new LanConfigSecurityGetAnonymousLoginRequest()));
        }

        public Task<LanConfigSecurityGetCurrentUserResponse> LanConfigSecurityGetCurrentUserAsync()
        {
            return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.GetCurrentUserAsync(new LanConfigSecurityGetCurrentUserRequest()));
        }

        public Task<LanConfigSecurityGetInfoResponse> LanConfigSecurityGetInfoAsync()
        {
            return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.GetInfoAsync(new LanConfigSecurityGetInfoRequest()));
        }

        public Task<LanConfigSecurityGetUserListResponse> LanConfigSecurityGetUserListAsync()
        {
            return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.GetUserListAsync(new LanConfigSecurityGetUserListRequest()));
        }

        public Task<LanConfigSecuritySetConfigPasswordResponse> LanConfigSecuritySetConfigPasswordAsync(string password)
        {
            return ExecuteAsync(GetFritzLanConfigSecurityServiceClient(), q => q.SetConfigPasswordAsync(new LanConfigSecuritySetConfigPasswordRequest { Password = password }));
        }

        public Task<Layer3ForwardingGetDefaultConnectionServiceResponse> Layer3ForwardingGetDefaultConnectionServiceAsync()
        {
            return ExecuteAsync(GetFritzLayer3ForwardingServiceClient(), q => q.GetDefaultConnectionServiceAsync(new Layer3ForwardingGetDefaultConnectionServiceRequest()));
        }

        public Task<WanDslInterfaceConfigGetDSLDiagnoseInfoResponse> WanDslInterfaceConfigGetDSLDiagnoseInfoAsync()
        {
            return ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(), q => q.GetDSLDiagnoseInfoAsync(new WanDslInterfaceConfigGetDSLDiagnoseInfoRequest()));
        }

        public Task<WanDslInterfaceConfigGetDSLInfoResponse> WanDslInterfaceConfigGetDSLInfoAsync()
        {
            return ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(), q => q.GetDSLInfoAsync(new WanDslInterfaceConfigGetDSLInfoRequest()));
        }

        public Task<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoAsync()
        {
            return ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(), q => q.GetInfoAsync(new WanDslInterfaceConfigGetInfoRequest()));
        }

        public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> WanDslInterfaceConfigGetStatisticsTotalAsync()
        {
            return ExecuteAsync(GetFritzWanDslInterfaceConfigServiceClient(), q => q.GetStatisticsTotalAsync(new WanDslInterfaceConfigGetStatisticsTotalRequest()));
        }

        public Task<WanPppConnectionGetInfoResponse> WanPppConnectionGetInfoAsync()
        {
            return ExecuteAsync(GetFritzWanPppConnectionServiceClient(), q => q.GetInfoAsync(new WanPppConnectionGetInfoRequest()));
        }

        // ****************************   here come the interfaces    *************************************


        // RoSchmi
        private IFritzWanCommonInterfaceConfigService GetFritzWanCommonInterfaceConfigServiceClient(bool secure = false, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            bool theBool = secure;
            ushort? thePort = port;
            NetworkCredential? theNetwokcredential = networkCredential;


            return fritzWanCommonlInterfaceConfigServiceClientFactory.Build((q, r, t) => new FritzWanCommonInterfaceConfigService(q, r, t!), InternetGatewayDevice!.PreferredLocation, true, FritzWanCommonInterfaceConfigService.ControlUrl, InternetGatewayDevice!.SecurityPort, NetworkCredential);

        }


        private IFritzLanConfigSecurityService GetFritzLanConfigSecurityServiceClient()
        {
            return fritzLanConfigSecurityServiceClientFactory.Build((q, r, t) => new FritzLanConfigSecurityService(q, r, t), InternetGatewayDevice!.PreferredLocation, true, FritzLanConfigSecurityService.ControlUrl, InternetGatewayDevice!.SecurityPort, NetworkCredential);
        }

        private IFritzDeviceInfoService GetFritzDeviceInfoServiceClient(bool secure = false, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return fritzDeviceInfoServiceClientFactory.Build((q, r, t) => new FritzDeviceInfoService(q, r, t), InternetGatewayDevice!.PreferredLocation, secure, FritzDeviceInfoService.ControlUrl, port, networkCredential);
        }

        private IFritzLayer3ForwardingService GetFritzLayer3ForwardingServiceClient()
        {
            return fritzLayer3ForwardingServiceClientFactory.Build((q, r, t) => new FritzLayer3ForwardingService(q, r, t!), InternetGatewayDevice!.PreferredLocation, true, FritzLayer3ForwardingService.ControlUrl, InternetGatewayDevice!.SecurityPort, NetworkCredential);
        }

        private IFritzWanDslInterfaceConfigService GetFritzWanDslInterfaceConfigServiceClient()
        {
            return fritzWanDslInterfaceConfigServiceClientFactory.Build((q, r, t) => new FritzWanDslInterfaceConfigService(q, r, t!), InternetGatewayDevice!.PreferredLocation, true, FritzWanDslInterfaceConfigService.ControlUrl, InternetGatewayDevice!.SecurityPort, NetworkCredential);
        }

        private IFritzWanPppConnectionService GetFritzWanPppConnectionServiceClient()
        {
            return fritzWanPppConnectionServiceClientFactory.Build((q, r, t) => new FritzWanPppConnectionService(q, r, t!), InternetGatewayDevice!.PreferredLocation, true, FritzWanPppConnectionService.ControlUrl, InternetGatewayDevice!.SecurityPort, NetworkCredential);
        }
    }
}
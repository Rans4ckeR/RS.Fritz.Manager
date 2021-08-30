namespace RS.Fritz.Manager.UI
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class DeviceInfoViewModel : FritzServiceViewModel
    {
        private readonly IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory;
        private readonly DeviceInfoSetProvisioningCodeViewModel deviceInfoSetProvisioningCodeViewModel;

        private DeviceInfoGetSecurityPortResponse? deviceInfoGetSecurityPortResponse;
        private DeviceInfoGetInfoResponse? deviceInfoGetInfoResponse;
        private DeviceInfoGetDeviceLogResponse? deviceInfoGetDeviceLogResponse;

        public DeviceInfoViewModel(ILogger logger, DeviceLoginInfo deviceLoginInfo, DeviceInfoSetProvisioningCodeViewModel deviceInfoSetProvisioningCodeViewModel, IServiceOperationHandler serviceOperationHandler, IClientFactory<IFritzDeviceInfoService> fritzDeviceInfoServiceClientFactory)
              : base(logger, deviceLoginInfo, serviceOperationHandler)
        {
            this.fritzDeviceInfoServiceClientFactory = fritzDeviceInfoServiceClientFactory;
            this.deviceInfoSetProvisioningCodeViewModel = deviceInfoSetProvisioningCodeViewModel;
        }

        public DeviceInfoGetSecurityPortResponse? DeviceInfoGetSecurityPortResponse
        {
            get => deviceInfoGetSecurityPortResponse; set { _ = SetProperty(ref deviceInfoGetSecurityPortResponse, value); }
        }

        public DeviceInfoGetInfoResponse? DeviceInfoGetInfoResponse
        {
            get => deviceInfoGetInfoResponse; set { _ = SetProperty(ref deviceInfoGetInfoResponse, value); }
        }

        public DeviceInfoGetDeviceLogResponse? DeviceInfoGetDeviceLogResponse
        {
            get => deviceInfoGetDeviceLogResponse; set { _ = SetProperty(ref deviceInfoGetDeviceLogResponse, value); }
        }

        public DeviceInfoSetProvisioningCodeViewModel DeviceInfoSetProvisioningCodeViewModel
        {
            get => deviceInfoSetProvisioningCodeViewModel;
        }

        protected override async Task DoExecuteDefaultCommandAsync(NetworkCredential networkCredential)
        {
            await Domain.TaskExtensions.WhenAllSafe(new Task[]
                {
                    GetDeviceInfoGetSecurityPortAsync(),
                    GetDeviceInfoGetInfoAsync(networkCredential),
                    GetDeviceInfoGetDeviceLogAsync(networkCredential)
                });
        }

        private async Task GetDeviceInfoGetSecurityPortAsync()
        {
            DeviceInfoGetSecurityPortResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(false), q => q.GetSecurityPortAsync(new DeviceInfoGetSecurityPortRequest()));
        }

        private async Task GetDeviceInfoGetInfoAsync(NetworkCredential networkCredential)
        {
            DeviceInfoGetInfoResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(true, DeviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetInfoAsync(new DeviceInfoGetInfoRequest()));
        }

        private async Task GetDeviceInfoGetDeviceLogAsync(NetworkCredential networkCredential)
        {
            DeviceInfoGetDeviceLogResponse = await ServiceOperationHandler.ExecuteAsync(GetFritzDeviceInfoServiceClient(true, DeviceLoginInfo.Device!.SecurityPort, networkCredential), q => q.GetDeviceLogAsync(new DeviceInfoGetDeviceLogRequest()));
        }

        private IFritzDeviceInfoService GetFritzDeviceInfoServiceClient(bool secure = true, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return fritzDeviceInfoServiceClientFactory.Build((q, r, t) => new FritzDeviceInfoService(q, r, t), DeviceLoginInfo.Device!.PreferredLocation, secure, FritzDeviceInfoService.ControlUrl, port, networkCredential);
        }
    }
}
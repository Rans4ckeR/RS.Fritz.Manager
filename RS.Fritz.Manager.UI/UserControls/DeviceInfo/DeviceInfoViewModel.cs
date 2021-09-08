namespace RS.Fritz.Manager.UI
{
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed class DeviceInfoViewModel : FritzServiceViewModel
    {
        private readonly DeviceInfoSetProvisioningCodeViewModel deviceInfoSetProvisioningCodeViewModel;

        private DeviceInfoGetSecurityPortResponse? deviceInfoGetSecurityPortResponse;
        private DeviceInfoGetInfoResponse? deviceInfoGetInfoResponse;
        private DeviceInfoGetDeviceLogResponse? deviceInfoGetDeviceLogResponse;

        public DeviceInfoViewModel(ILogger logger, DeviceInfoSetProvisioningCodeViewModel deviceInfoSetProvisioningCodeViewModel, IFritzServiceOperationHandler fritzServiceOperationHandler)
            : base(logger, fritzServiceOperationHandler)
        {
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

        protected override async Task DoExecuteDefaultCommandAsync()
        {
            await Domain.TaskExtensions.WhenAllSafe(new[]
                {
                    GetDeviceInfoGetSecurityPortAsync(),
                    GetDeviceInfoGetInfoAsync(),
                    GetDeviceInfoGetDeviceLogAsync()
                });
        }

        private async Task GetDeviceInfoGetSecurityPortAsync()
        {
            DeviceInfoGetSecurityPortResponse = await FritzServiceOperationHandler.DeviceInfoGetSecurityPortAsync();
        }

        private async Task GetDeviceInfoGetInfoAsync()
        {
            DeviceInfoGetInfoResponse = await FritzServiceOperationHandler.DeviceInfoGetInfoAsync();
        }

        private async Task GetDeviceInfoGetDeviceLogAsync()
        {
            DeviceInfoGetDeviceLogResponse = await FritzServiceOperationHandler.DeviceInfoGetDeviceLogAsync();
        }
    }
}
namespace RS.Fritz.Manager.UI;

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class DeviceInfoViewModel : FritzServiceViewModel
{
    private DeviceInfoGetSecurityPortResponse? deviceInfoGetSecurityPortResponse;
    private DeviceInfoGetInfoResponse? deviceInfoGetInfoResponse;
    private DeviceInfoGetDeviceLogResponse? deviceInfoGetDeviceLogResponse;

    public DeviceInfoViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, DeviceInfoSetProvisioningCodeViewModel deviceInfoSetProvisioningCodeViewModel)
        : base(deviceLoginInfo, logger)
    {
        DeviceInfoSetProvisioningCodeViewModel = deviceInfoSetProvisioningCodeViewModel;
    }

    public DeviceInfoGetSecurityPortResponse? DeviceInfoGetSecurityPortResponse
    {
        get => deviceInfoGetSecurityPortResponse;
        private set { _ = SetProperty(ref deviceInfoGetSecurityPortResponse, value); }
    }

    public DeviceInfoGetInfoResponse? DeviceInfoGetInfoResponse
    {
        get => deviceInfoGetInfoResponse;
        private set { _ = SetProperty(ref deviceInfoGetInfoResponse, value); }
    }

    public DeviceInfoGetDeviceLogResponse? DeviceInfoGetDeviceLogResponse
    {
        get => deviceInfoGetDeviceLogResponse;
        private set { _ = SetProperty(ref deviceInfoGetDeviceLogResponse, value); }
    }

    public DeviceInfoSetProvisioningCodeViewModel DeviceInfoSetProvisioningCodeViewModel { get; }

    protected override async Task DoExecuteDefaultCommandAsync()
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetDeviceInfoGetSecurityPortAsync(),
                GetDeviceInfoGetInfoAsync(),
                GetDeviceInfoGetDeviceLogAsync()
            });
    }

    private async Task GetDeviceInfoGetSecurityPortAsync()
    {
        DeviceInfoGetSecurityPortResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.DeviceInfoGetSecurityPortAsync(d));
    }

    private async Task GetDeviceInfoGetInfoAsync()
    {
        DeviceInfoGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.DeviceInfoGetInfoAsync(d));
    }

    private async Task GetDeviceInfoGetDeviceLogAsync()
    {
        DeviceInfoGetDeviceLogResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.DeviceInfoGetDeviceLogAsync(d));
    }
}
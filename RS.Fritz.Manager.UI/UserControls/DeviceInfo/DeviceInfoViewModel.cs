namespace RS.Fritz.Manager.UI;

internal sealed class DeviceInfoViewModel : FritzServiceViewModel
{
    private DeviceInfoGetSecurityPortResponse? deviceInfoGetSecurityPortResponse;
    private DeviceInfoGetInfoResponse? deviceInfoGetInfoResponse;
    private DeviceInfoGetDeviceLogResponse? deviceInfoGetDeviceLogResponse;

    public DeviceInfoViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, DeviceInfoSetProvisioningCodeViewModel deviceInfoSetProvisioningCodeViewModel)
        : base(deviceLoginInfo, logger, "DeviceInfo")
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

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
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
        DeviceInfoGetSecurityPortResponse = await ExecuteApiAsync(q => q.DeviceInfoGetSecurityPortAsync());
    }

    private async Task GetDeviceInfoGetInfoAsync()
    {
        DeviceInfoGetInfoResponse = await ExecuteApiAsync(q => q.DeviceInfoGetInfoAsync());
    }

    private async Task GetDeviceInfoGetDeviceLogAsync()
    {
        DeviceInfoGetDeviceLogResponse = await ExecuteApiAsync(q => q.DeviceInfoGetDeviceLogAsync());
    }
}
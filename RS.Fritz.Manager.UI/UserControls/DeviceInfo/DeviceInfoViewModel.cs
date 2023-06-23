namespace RS.Fritz.Manager.UI;

internal sealed class DeviceInfoViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, DeviceInfoSetProvisioningCodeViewModel deviceInfoSetProvisioningCodeViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "DeviceInfo")
{
    private KeyValuePair<DeviceInfoGetSecurityPortResponse?, UPnPFault?>? deviceInfoGetSecurityPortResponse;
    private KeyValuePair<DeviceInfoGetInfoResponse?, UPnPFault?>? deviceInfoGetInfoResponse;
    private KeyValuePair<DeviceInfoGetDeviceLogResponse?, UPnPFault?>? deviceInfoGetDeviceLogResponse;

    public KeyValuePair<DeviceInfoGetSecurityPortResponse?, UPnPFault?>? DeviceInfoGetSecurityPortResponse
    {
        get => deviceInfoGetSecurityPortResponse;
        private set => _ = SetProperty(ref deviceInfoGetSecurityPortResponse, value);
    }

    public KeyValuePair<DeviceInfoGetInfoResponse?, UPnPFault?>? DeviceInfoGetInfoResponse
    {
        get => deviceInfoGetInfoResponse;
        private set => _ = SetProperty(ref deviceInfoGetInfoResponse, value);
    }

    public KeyValuePair<DeviceInfoGetDeviceLogResponse?, UPnPFault?>? DeviceInfoGetDeviceLogResponse
    {
        get => deviceInfoGetDeviceLogResponse;
        private set => _ = SetProperty(ref deviceInfoGetDeviceLogResponse, value);
    }

    public DeviceInfoSetProvisioningCodeViewModel DeviceInfoSetProvisioningCodeViewModel { get; } = deviceInfoSetProvisioningCodeViewModel;

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(
            new[]
            {
                GetDeviceInfoGetSecurityPortAsync(),
                GetDeviceInfoGetInfoAsync(),
                GetDeviceInfoGetDeviceLogAsync()
            },
            true);
    }

    private async Task GetDeviceInfoGetSecurityPortAsync() => DeviceInfoGetSecurityPortResponse = await ExecuteApiAsync(q => q.DeviceInfoGetSecurityPortAsync()).ConfigureAwait(true);

    private async Task GetDeviceInfoGetInfoAsync() => DeviceInfoGetInfoResponse = await ExecuteApiAsync(q => q.DeviceInfoGetInfoAsync()).ConfigureAwait(true);

    private async Task GetDeviceInfoGetDeviceLogAsync() => DeviceInfoGetDeviceLogResponse = await ExecuteApiAsync(q => q.DeviceInfoGetDeviceLogAsync()).ConfigureAwait(true);
}
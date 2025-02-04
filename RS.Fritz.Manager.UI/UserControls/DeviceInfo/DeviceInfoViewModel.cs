﻿namespace RS.Fritz.Manager.UI;

internal sealed class DeviceInfoViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<DeviceInfoViewModel> logger, DeviceInfoSetProvisioningCodeViewModel deviceInfoSetProvisioningCodeViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "DeviceInfo")
{
    public KeyValuePair<DeviceInfoGetSecurityPortResponse?, UPnPFault?>? DeviceInfoGetSecurityPortResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<DeviceInfoGetInfoResponse?, UPnPFault?>? DeviceInfoGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<DeviceInfoGetDeviceLogResponse?, UPnPFault?>? DeviceInfoGetDeviceLogResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public DeviceInfoSetProvisioningCodeViewModel DeviceInfoSetProvisioningCodeViewModel { get; } = deviceInfoSetProvisioningCodeViewModel;

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => Task.WhenAll(GetDeviceInfoGetSecurityPortAsync(), GetDeviceInfoGetInfoAsync(), GetDeviceInfoGetDeviceLogAsync()).Evaluate(ConfigureAwaitOptions.ContinueOnCapturedContext);

    private async Task GetDeviceInfoGetSecurityPortAsync() => DeviceInfoGetSecurityPortResponse = await ExecuteApiAsync(static q => q.DeviceInfoGetSecurityPortAsync()).ConfigureAwait(true);

    private async Task GetDeviceInfoGetInfoAsync() => DeviceInfoGetInfoResponse = await ExecuteApiAsync(static q => q.DeviceInfoGetInfoAsync()).ConfigureAwait(true);

    private async Task GetDeviceInfoGetDeviceLogAsync() => DeviceInfoGetDeviceLogResponse = await ExecuteApiAsync(static q => q.DeviceInfoGetDeviceLogAsync()).ConfigureAwait(true);
}
namespace RS.Fritz.Manager.UI;

internal sealed class DeviceInfoSetProvisioningCodeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<DeviceInfoSetProvisioningCodeRequest, DeviceInfoSetProvisioningCodeResponse>(deviceLoginInfo, logger, "SetProvisioningCode", "Update ProvisioningCode", (d, r) => d.DeviceInfoSetProvisioningCodeAsync(r))
{
    private string? provisioningCode;

    public string? ProvisioningCode
    {
        get => provisioningCode;
        set
        {
            if (SetProperty(ref provisioningCode, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override DeviceInfoSetProvisioningCodeRequest BuildRequest() => new(ProvisioningCode!);
}
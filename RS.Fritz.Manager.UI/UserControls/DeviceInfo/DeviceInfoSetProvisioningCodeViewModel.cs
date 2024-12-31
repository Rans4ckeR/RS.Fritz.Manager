namespace RS.Fritz.Manager.UI;

internal sealed class DeviceInfoSetProvisioningCodeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<DeviceInfoSetProvisioningCodeViewModel> logger)
    : ManualOperationViewModel<DeviceInfoSetProvisioningCodeRequest, DeviceInfoSetProvisioningCodeResponse>(deviceLoginInfo, logger, "SetProvisioningCode", "Update ProvisioningCode", static (d, r) => d.DeviceInfoSetProvisioningCodeAsync(r))
{
    public string? ProvisioningCode
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override DeviceInfoSetProvisioningCodeRequest BuildRequest() => new(ProvisioningCode!);
}
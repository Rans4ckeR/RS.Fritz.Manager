﻿namespace RS.Fritz.Manager.UI;

internal sealed class DeviceInfoSetProvisioningCodeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<DeviceInfoSetProvisioningCodeRequest, DeviceInfoSetProvisioningCodeResponse>(deviceLoginInfo, logger, "SetProvisioningCode", "Update ProvisioningCode", (d, r) => d.DeviceInfoSetProvisioningCodeAsync(r))
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
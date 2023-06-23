namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

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
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override DeviceInfoSetProvisioningCodeRequest BuildRequest() => new(ProvisioningCode!);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(ProvisioningCode):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}
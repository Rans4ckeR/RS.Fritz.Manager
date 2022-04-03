namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class DeviceInfoSetProvisioningCodeViewModel : SetValuesViewModel<DeviceInfoSetProvisioningCodeRequest, DeviceInfoSetProvisioningCodeResponse>
{
    private string? provisioningCode;

    public DeviceInfoSetProvisioningCodeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetProvisioningCode", "Update ProvisioningCode", (d, r) => d.DeviceInfoSetProvisioningCodeAsync(r))
    {
    }

    public string? ProvisioningCode
    {
        get => provisioningCode;
        set
        {
            if (SetProperty(ref provisioningCode, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override DeviceInfoSetProvisioningCodeRequest BuildRequest()
    {
        return new DeviceInfoSetProvisioningCodeRequest(ProvisioningCode!);
    }

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
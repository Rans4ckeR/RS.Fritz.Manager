namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetManagementServerPasswordViewModel : ManualOperationViewModel<ManagementServerSetManagementServerPasswordRequest, ManagementServerSetManagementServerPasswordResponse>
{
    private string? password;

    public ManagementServerSetManagementServerPasswordViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetManagementServerPassword", "Update ManagementServerPassword", (d, r) => d.ManagementServerSetManagementServerPasswordAsync(r))
    {
    }

    public string? Password
    {
        get => password;
        set
        {
            if (SetProperty(ref password, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override ManagementServerSetManagementServerPasswordRequest BuildRequest()
    {
        return new(Password!);
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(Password):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}
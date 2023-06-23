namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetManagementServerPasswordViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerPasswordRequest, ManagementServerSetManagementServerPasswordResponse>(deviceLoginInfo, logger, "SetManagementServerPassword", "Update ManagementServerPassword", (d, r) => d.ManagementServerSetManagementServerPasswordAsync(r))
{
    private string? password;

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
        => new(Password!);

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
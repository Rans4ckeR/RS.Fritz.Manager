namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetManagementServerUsernameViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerUsernameRequest, ManagementServerSetManagementServerUsernameResponse>(deviceLoginInfo, logger, "SetManagementServerUsername", "Update ManagementServerUsername", (d, r) => d.ManagementServerSetManagementServerUsernameAsync(r))
{
    private string? username;

    public string? Username
    {
        get => username;
        set
        {
            if (SetProperty(ref username, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override ManagementServerSetManagementServerUsernameRequest BuildRequest()
        => new(Username!);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(Username):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}
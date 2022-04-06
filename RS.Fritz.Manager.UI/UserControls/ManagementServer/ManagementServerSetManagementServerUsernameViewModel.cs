namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetManagementServerUsernameViewModel : ManualOperationViewModel<ManagementServerSetManagementServerUsernameRequest, ManagementServerSetManagementServerUsernameResponse>
{
    private string? username;

    public ManagementServerSetManagementServerUsernameViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetManagementServerUsername", "Update ManagementServerUsername", (d, r) => d.ManagementServerSetManagementServerUsernameAsync(r))
    {
    }

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
    {
        return new ManagementServerSetManagementServerUsernameRequest(Username!);
    }

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
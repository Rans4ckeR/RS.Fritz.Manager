namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetConnectionRequestAuthenticationViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetConnectionRequestAuthenticationRequest, ManagementServerSetConnectionRequestAuthenticationResponse>(deviceLoginInfo, logger, "SetConnectionRequestAuthentication", "Update ConnectionRequestAuthentication", (d, r) => d.ManagementServerSetConnectionRequestAuthenticationAsync(r))
{
    private string? connectionRequestUsername;
    private string? connectionRequestPassword;

    public string? ConnectionRequestUsername
    {
        get => connectionRequestUsername;
        set
        {
            if (SetProperty(ref connectionRequestUsername, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public string? ConnectionRequestPassword
    {
        get => connectionRequestPassword;
        set
        {
            if (SetProperty(ref connectionRequestPassword, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override ManagementServerSetConnectionRequestAuthenticationRequest BuildRequest()
        => new(ConnectionRequestUsername!, ConnectionRequestPassword!);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(ConnectionRequestUsername):
            case nameof(ConnectionRequestPassword):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}
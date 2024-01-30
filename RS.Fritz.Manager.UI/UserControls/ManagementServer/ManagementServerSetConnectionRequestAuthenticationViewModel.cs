namespace RS.Fritz.Manager.UI;

internal sealed class
    ManagementServerSetConnectionRequestAuthenticationViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
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
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public string? ConnectionRequestPassword
    {
        get => connectionRequestPassword;
        set
        {
            if (SetProperty(ref connectionRequestPassword, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetConnectionRequestAuthenticationRequest BuildRequest()
        => new(ConnectionRequestUsername!, ConnectionRequestPassword!);
}
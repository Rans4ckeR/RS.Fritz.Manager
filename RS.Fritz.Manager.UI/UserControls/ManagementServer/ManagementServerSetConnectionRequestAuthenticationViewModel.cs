namespace RS.Fritz.Manager.UI;

internal sealed class
    ManagementServerSetConnectionRequestAuthenticationViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<ManagementServerSetConnectionRequestAuthenticationViewModel> logger)
    : ManualOperationViewModel<ManagementServerSetConnectionRequestAuthenticationRequest, ManagementServerSetConnectionRequestAuthenticationResponse>(deviceLoginInfo, logger, "SetConnectionRequestAuthentication", "Update ConnectionRequestAuthentication", static (d, r) => d.ManagementServerSetConnectionRequestAuthenticationAsync(r))
{
    public string? ConnectionRequestUsername
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public string? ConnectionRequestPassword
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetConnectionRequestAuthenticationRequest BuildRequest()
        => new(ConnectionRequestUsername!, ConnectionRequestPassword!);
}
namespace RS.Fritz.Manager.UI;

internal sealed class
    ManagementServerSetManagementServerUsernameViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerUsernameRequest, ManagementServerSetManagementServerUsernameResponse>(deviceLoginInfo, logger, "SetManagementServerUsername", "Update ManagementServerUsername", (d, r) => d.ManagementServerSetManagementServerUsernameAsync(r))
{
    private string? username;

    public string? Username
    {
        get => username;
        set
        {
            if (SetProperty(ref username, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetManagementServerUsernameRequest BuildRequest()
        => new(Username!);
}
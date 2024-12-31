namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetManagementServerUsernameViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<ManagementServerSetManagementServerUsernameViewModel> logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerUsernameRequest, ManagementServerSetManagementServerUsernameResponse>(deviceLoginInfo, logger, "SetManagementServerUsername", "Update ManagementServerUsername", static (d, r) => d.ManagementServerSetManagementServerUsernameAsync(r))
{
    public string? Username
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetManagementServerUsernameRequest BuildRequest()
        => new(Username!);
}
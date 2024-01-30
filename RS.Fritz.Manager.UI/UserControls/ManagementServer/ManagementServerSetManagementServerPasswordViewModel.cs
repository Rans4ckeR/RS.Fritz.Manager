namespace RS.Fritz.Manager.UI;

internal sealed class
    ManagementServerSetManagementServerPasswordViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerPasswordRequest, ManagementServerSetManagementServerPasswordResponse>(deviceLoginInfo, logger, "SetManagementServerPassword", "Update ManagementServerPassword", (d, r) => d.ManagementServerSetManagementServerPasswordAsync(r))
{
    private string? password;

    public string? Password
    {
        get => password;
        set
        {
            if (SetProperty(ref password, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetManagementServerPasswordRequest BuildRequest()
        => new(Password!);
}
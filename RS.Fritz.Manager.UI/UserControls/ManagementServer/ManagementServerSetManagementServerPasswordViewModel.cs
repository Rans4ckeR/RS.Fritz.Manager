namespace RS.Fritz.Manager.UI;

internal sealed class
    ManagementServerSetManagementServerPasswordViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetManagementServerPasswordRequest, ManagementServerSetManagementServerPasswordResponse>(deviceLoginInfo, logger, "SetManagementServerPassword", "Update ManagementServerPassword", static (d, r) => d.ManagementServerSetManagementServerPasswordAsync(r))
{
    public string? Password
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetManagementServerPasswordRequest BuildRequest()
        => new(Password!);
}
namespace RS.Fritz.Manager.UI;

internal sealed class LanConfigSecuritySetConfigPasswordViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<LanConfigSecuritySetConfigPasswordRequest, LanConfigSecuritySetConfigPasswordResponse>(deviceLoginInfo, logger, "SetConfigPassword", "Update Password", (d, r) => d.LanConfigSecuritySetConfigPasswordAsync(r))
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

    protected override LanConfigSecuritySetConfigPasswordRequest BuildRequest()
        => new(Password!);
}
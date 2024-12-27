namespace RS.Fritz.Manager.UI;

internal sealed class LanConfigSecuritySetConfigPasswordViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<LanConfigSecuritySetConfigPasswordRequest, LanConfigSecuritySetConfigPasswordResponse>(deviceLoginInfo, logger, "SetConfigPassword", "Update Password", static (d, r) => d.LanConfigSecuritySetConfigPasswordAsync(r))
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

    protected override LanConfigSecuritySetConfigPasswordRequest BuildRequest()
        => new(Password!);
}
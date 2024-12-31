namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceSetConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<UserInterfaceSetConfigViewModel> logger)
    : ManualOperationViewModel<UserInterfaceSetConfigRequest, UserInterfaceSetConfigResponse>(deviceLoginInfo, logger, "SetConfig", "Set Config", static (d, r) => d.UserInterfaceSetConfigAsync(r))
{
    public string? AutoUpdateMode
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override UserInterfaceSetConfigRequest BuildRequest()
        => new(AutoUpdateMode!);
}
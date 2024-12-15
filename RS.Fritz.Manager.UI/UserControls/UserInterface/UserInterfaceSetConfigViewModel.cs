namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceSetConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceSetConfigRequest, UserInterfaceSetConfigResponse>(deviceLoginInfo, logger, "SetConfig", "Set Config", (d, r) => d.UserInterfaceSetConfigAsync(r))
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
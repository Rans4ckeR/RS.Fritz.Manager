namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceSetConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceSetConfigRequest, UserInterfaceSetConfigResponse>(deviceLoginInfo, logger, "SetConfig", "Set Config", (d, r) => d.UserInterfaceSetConfigAsync(r))
{
    private string? autoUpdateMode;

    public string? AutoUpdateMode
    {
        get => autoUpdateMode;
        set
        {
            if (SetProperty(ref autoUpdateMode, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override UserInterfaceSetConfigRequest BuildRequest()
        => new(AutoUpdateMode!);
}
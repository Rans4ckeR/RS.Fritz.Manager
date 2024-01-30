namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetTr069EnableViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetTr069EnableRequest, ManagementServerSetTr069EnableResponse>(deviceLoginInfo, logger, "SetTr069Enable", "Update Tr069Enable", (d, r) => d.ManagementServerSetTr069EnableAsync(r))
{
    private bool? tr069Enabled;

    public bool? Tr069Enabled
    {
        get => tr069Enabled;
        set
        {
            if (SetProperty(ref tr069Enabled, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetTr069EnableRequest BuildRequest()
        => new(Tr069Enabled!.Value);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Tr069Enabled.HasValue;
}
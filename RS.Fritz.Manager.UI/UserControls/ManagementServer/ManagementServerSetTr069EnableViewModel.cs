namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetTr069EnableViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetTr069EnableRequest, ManagementServerSetTr069EnableResponse>(deviceLoginInfo, logger, "SetTr069Enable", "Update Tr069Enable", static (d, r) => d.ManagementServerSetTr069EnableAsync(r))
{
    public bool? Tr069Enabled
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetTr069EnableRequest BuildRequest()
        => new(Tr069Enabled!.Value);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Tr069Enabled.HasValue;
}
namespace RS.Fritz.Manager.UI;

internal sealed class WanCommonInterfaceConfigSetWanAccessTypeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<WanCommonInterfaceConfigSetWanAccessTypeRequest, WanCommonInterfaceConfigSetWanAccessTypeResponse>(deviceLoginInfo, logger, "SetWanAccessType", "Update WanAccessType", (d, r) => d.WanCommonInterfaceConfigSetWanAccessTypeAsync(r))
{
    public string? WanAccessType
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override WanCommonInterfaceConfigSetWanAccessTypeRequest BuildRequest()
        => new(WanAccessType!);
}
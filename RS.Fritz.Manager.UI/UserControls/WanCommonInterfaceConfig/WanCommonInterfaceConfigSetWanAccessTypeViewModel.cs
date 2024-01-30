namespace RS.Fritz.Manager.UI;

internal sealed class WanCommonInterfaceConfigSetWanAccessTypeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<WanCommonInterfaceConfigSetWanAccessTypeRequest, WanCommonInterfaceConfigSetWanAccessTypeResponse>(deviceLoginInfo, logger, "SetWanAccessType", "Update WanAccessType", (d, r) => d.WanCommonInterfaceConfigSetWanAccessTypeAsync(r))
{
    private string? wanAccessType;

    public string? WanAccessType
    {
        get => wanAccessType;
        set
        {
            if (SetProperty(ref wanAccessType, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override WanCommonInterfaceConfigSetWanAccessTypeRequest BuildRequest()
        => new(WanAccessType!);
}
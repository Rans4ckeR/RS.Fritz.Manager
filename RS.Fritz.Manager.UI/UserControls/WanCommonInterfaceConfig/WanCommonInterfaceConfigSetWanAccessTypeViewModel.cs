namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

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
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override WanCommonInterfaceConfigSetWanAccessTypeRequest BuildRequest()
        => new(WanAccessType!);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(WanAccessType):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}
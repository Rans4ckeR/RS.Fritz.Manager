namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class WanCommonInterfaceConfigSetWanAccessTypeViewModel : SetValuesViewModel<WanCommonInterfaceConfigSetWanAccessTypeRequest, WanCommonInterfaceConfigSetWanAccessTypeResponse>
{
    private string? wanAccessType;

    public WanCommonInterfaceConfigSetWanAccessTypeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetWanAccessType", "Update WanAccessType", (d, r) => d.WanCommonInterfaceConfigSetWanAccessTypeAsync(r))
    {
    }

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
    {
        return new WanCommonInterfaceConfigSetWanAccessTypeRequest(WanAccessType!);
    }

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
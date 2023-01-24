namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class UserInterfaceSetConfigViewModel : ManualOperationViewModel<UserInterfaceSetConfigRequest, UserInterfaceSetConfigResponse>
{
    private string? autoUpdateMode;

    public UserInterfaceSetConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetConfig", "Set Config", (d, r) => d.UserInterfaceSetConfigAsync(r))
    {
    }

    public string? AutoUpdateMode
    {
        get => autoUpdateMode;
        set
        {
            if (SetProperty(ref autoUpdateMode, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override UserInterfaceSetConfigRequest BuildRequest()
    {
        return new(AutoUpdateMode!);
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(AutoUpdateMode):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}
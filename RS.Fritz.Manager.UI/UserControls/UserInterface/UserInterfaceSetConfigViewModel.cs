namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

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
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override UserInterfaceSetConfigRequest BuildRequest()
        => new(AutoUpdateMode!);

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
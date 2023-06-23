namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

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
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override ManagementServerSetTr069EnableRequest BuildRequest()
        => new(Tr069Enabled!.Value);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(Tr069Enabled):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && Tr069Enabled.HasValue;
}
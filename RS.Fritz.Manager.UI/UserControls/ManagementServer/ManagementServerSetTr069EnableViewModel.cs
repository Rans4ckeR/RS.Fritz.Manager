namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetTr069EnableViewModel : ManualOperationViewModel<ManagementServerSetTr069EnableRequest, ManagementServerSetTr069EnableResponse>
{
    private bool? tr069Enabled;

    public ManagementServerSetTr069EnableViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "SetTr069Enable", "Update Tr069Enable", (d, r) => d.ManagementServerSetTr069EnableAsync(r))
    {
    }

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
    {
        return new ManagementServerSetTr069EnableRequest(Tr069Enabled!.Value);
    }

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
    {
        return base.GetCanExecuteDefaultCommand() && Tr069Enabled.HasValue;
    }
}
namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

internal sealed class ManagementServerSetPeriodicInformViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetPeriodicInformRequest, ManagementServerSetPeriodicInformResponse>(deviceLoginInfo, logger, "SetPeriodicInform", "Update PeriodicInform", (d, r) => d.ManagementServerSetPeriodicInformAsync(r))
{
    private bool? periodicInformEnable;
    private ushort? periodicInformInterval;
    private DateTime? periodicInformTime;

    public bool? PeriodicInformEnable
    {
        get => periodicInformEnable;
        set
        {
            if (SetProperty(ref periodicInformEnable, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public ushort? PeriodicInformInterval
    {
        get => periodicInformInterval;
        set
        {
            if (SetProperty(ref periodicInformInterval, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public DateTime? PeriodicInformTime
    {
        get => periodicInformTime;
        set
        {
            if (SetProperty(ref periodicInformTime, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override ManagementServerSetPeriodicInformRequest BuildRequest()
        => new(PeriodicInformEnable!.Value, PeriodicInformInterval!.Value, PeriodicInformTime!.Value);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(PeriodicInformEnable):
            case nameof(PeriodicInformInterval):
            case nameof(PeriodicInformTime):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && PeriodicInformEnable.HasValue && PeriodicInformInterval.HasValue && PeriodicInformTime.HasValue;
}
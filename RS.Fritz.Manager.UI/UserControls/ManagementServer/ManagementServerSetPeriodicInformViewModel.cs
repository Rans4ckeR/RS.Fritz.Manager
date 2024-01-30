namespace RS.Fritz.Manager.UI;

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
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public ushort? PeriodicInformInterval
    {
        get => periodicInformInterval;
        set
        {
            if (SetProperty(ref periodicInformInterval, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public DateTime? PeriodicInformTime
    {
        get => periodicInformTime;
        set
        {
            if (SetProperty(ref periodicInformTime, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetPeriodicInformRequest BuildRequest()
        => new(PeriodicInformEnable!.Value, PeriodicInformInterval!.Value, PeriodicInformTime!.Value);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && PeriodicInformEnable.HasValue && PeriodicInformInterval.HasValue && PeriodicInformTime.HasValue;
}
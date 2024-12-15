namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerSetPeriodicInformViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<ManagementServerSetPeriodicInformRequest, ManagementServerSetPeriodicInformResponse>(deviceLoginInfo, logger, "SetPeriodicInform", "Update PeriodicInform", (d, r) => d.ManagementServerSetPeriodicInformAsync(r))
{
    public bool? PeriodicInformEnable
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public ushort? PeriodicInformInterval
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public DateTime? PeriodicInformTime
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override ManagementServerSetPeriodicInformRequest BuildRequest()
        => new(PeriodicInformEnable!.Value, PeriodicInformInterval!.Value, PeriodicInformTime!.Value);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && PeriodicInformEnable.HasValue && PeriodicInformInterval.HasValue && PeriodicInformTime.HasValue;
}
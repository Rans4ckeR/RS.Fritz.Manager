namespace RS.Fritz.Manager.UI;

internal sealed class TimeSetNtpServersViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<TimeSetNtpServersRequest, TimeSetNtpServersResponse>(deviceLoginInfo, logger, "SetNtpServers", "Update NtpServers", static (d, r) => d.TimeSetNtpServersAsync(r))
{
    public string? NtpServer1
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public string? NtpServer2
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override TimeSetNtpServersRequest BuildRequest()
        => new(NtpServer1!, NtpServer2!);
}
namespace RS.Fritz.Manager.UI;

internal sealed class TimeSetNtpServersViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<TimeSetNtpServersRequest, TimeSetNtpServersResponse>(deviceLoginInfo, logger, "SetNtpServers", "Update NtpServers", (d, r) => d.TimeSetNtpServersAsync(r))
{
    private string? ntpServer1;
    private string? ntpServer2;

    public string? NtpServer1
    {
        get => ntpServer1;
        set
        {
            if (SetProperty(ref ntpServer1, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public string? NtpServer2
    {
        get => ntpServer2;
        set
        {
            if (SetProperty(ref ntpServer2, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    protected override TimeSetNtpServersRequest BuildRequest()
        => new(NtpServer1!, NtpServer2!);
}
namespace RS.Fritz.Manager.UI;

using System.ComponentModel;

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
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public string? NtpServer2
    {
        get => ntpServer2;
        set
        {
            if (SetProperty(ref ntpServer2, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    protected override TimeSetNtpServersRequest BuildRequest()
        => new(NtpServer1!, NtpServer2!);

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(NtpServer1):
            case nameof(NtpServer2):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }
}
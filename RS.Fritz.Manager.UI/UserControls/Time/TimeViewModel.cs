namespace RS.Fritz.Manager.UI;

internal sealed class TimeViewModel : FritzServiceViewModel
{
    private KeyValuePair<TimeGetInfoResponse?, UPnPFault?>? timeGetInfoResponse;

    public TimeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, TimeSetNtpServersViewModel timeSetNtpServersViewModel)
        : base(deviceLoginInfo, logger, "Time")
    {
        TimeSetNtpServersViewModel = timeSetNtpServersViewModel;
    }

    public TimeSetNtpServersViewModel TimeSetNtpServersViewModel { get; }

    public KeyValuePair<TimeGetInfoResponse?, UPnPFault?>? TimeGetInfoResponse
    {
        get => timeGetInfoResponse;
        private set { _ = SetProperty(ref timeGetInfoResponse, value); }
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        TimeGetInfoResponse = await ExecuteApiAsync(q => q.TimeGetInfoAsync());
    }
}
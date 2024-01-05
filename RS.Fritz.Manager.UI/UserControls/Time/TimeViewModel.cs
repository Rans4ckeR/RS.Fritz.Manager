namespace RS.Fritz.Manager.UI;

internal sealed class TimeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, TimeSetNtpServersViewModel timeSetNtpServersViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "Time")
{
    private KeyValuePair<TimeGetInfoResponse?, UPnPFault?>? timeGetInfoResponse;

    public TimeSetNtpServersViewModel TimeSetNtpServersViewModel { get; } = timeSetNtpServersViewModel;

    public KeyValuePair<TimeGetInfoResponse?, UPnPFault?>? TimeGetInfoResponse
    {
        get => timeGetInfoResponse;
        private set => _ = SetProperty(ref timeGetInfoResponse, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => TimeGetInfoResponse = await ExecuteApiAsync(q => q.TimeGetInfoAsync()).ConfigureAwait(true);
}
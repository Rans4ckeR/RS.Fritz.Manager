namespace RS.Fritz.Manager.UI;

internal sealed class TimeViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, TimeSetNtpServersViewModel timeSetNtpServersViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "Time")
{
    public TimeSetNtpServersViewModel TimeSetNtpServersViewModel { get; } = timeSetNtpServersViewModel;

    public KeyValuePair<TimeGetInfoResponse?, UPnPFault?>? TimeGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => TimeGetInfoResponse = await ExecuteApiAsync(static q => q.TimeGetInfoAsync()).ConfigureAwait(true);
}
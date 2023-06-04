namespace RS.Fritz.Manager.UI;

internal sealed class AvmSpeedtestViewModel : FritzServiceViewModel
{
    private KeyValuePair<AvmSpeedtestGetInfoResponse?, UPnPFault?>? avmSpeedtestGetInfoResponse;
    private KeyValuePair<AvmSpeedtestGetStatisticsResponse?, UPnPFault?>? avmSpeedtestGetStatisticsResponse;

    public AvmSpeedtestViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "X_AVM-DE_Speedtest")
    {
    }

    public KeyValuePair<AvmSpeedtestGetInfoResponse?, UPnPFault?>? AvmSpeedtestGetInfoResponse
    {
        get => avmSpeedtestGetInfoResponse;
        private set => _ = SetProperty(ref avmSpeedtestGetInfoResponse, value);
    }

    public KeyValuePair<AvmSpeedtestGetStatisticsResponse?, UPnPFault?>? AvmSpeedtestGetStatisticsResponse
    {
        get => avmSpeedtestGetStatisticsResponse;
        private set => _ = SetProperty(ref avmSpeedtestGetStatisticsResponse, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(
            new[]
            {
                GetAvmSpeedtestGetInfoAsync(),
                GetAvmSpeedtestGetStatisticsAsync()
            },
            true);
    }

    private async Task GetAvmSpeedtestGetInfoAsync()
        => AvmSpeedtestGetInfoResponse = await ExecuteApiAsync(q => q.AvmSpeedtestGetInfoAsync()).ConfigureAwait(true);

    private async Task GetAvmSpeedtestGetStatisticsAsync()
        => AvmSpeedtestGetStatisticsResponse = await ExecuteApiAsync(q => q.AvmSpeedtestGetStatisticsAsync()).ConfigureAwait(true);
}
namespace RS.Fritz.Manager.UI;

internal sealed class AvmSpeedtestViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : FritzServiceViewModel(deviceLoginInfo, logger, "X_AVM-DE_Speedtest")
{
    private KeyValuePair<AvmSpeedtestGetInfoResponse?, UPnPFault?>? avmSpeedtestGetInfoResponse;
    private KeyValuePair<AvmSpeedtestGetStatisticsResponse?, UPnPFault?>? avmSpeedtestGetStatisticsResponse;

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
        => API.TaskExtensions.WhenAllSafe([GetAvmSpeedtestGetInfoAsync(), GetAvmSpeedtestGetStatisticsAsync()], true);

    private async Task GetAvmSpeedtestGetInfoAsync()
        => AvmSpeedtestGetInfoResponse = await ExecuteApiAsync(q => q.AvmSpeedtestGetInfoAsync()).ConfigureAwait(true);

    private async Task GetAvmSpeedtestGetStatisticsAsync()
        => AvmSpeedtestGetStatisticsResponse = await ExecuteApiAsync(q => q.AvmSpeedtestGetStatisticsAsync()).ConfigureAwait(true);
}
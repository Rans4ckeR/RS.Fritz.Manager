﻿namespace RS.Fritz.Manager.UI;

internal sealed class AvmSpeedtestViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<AvmSpeedtestViewModel> logger)
    : FritzServiceViewModel(deviceLoginInfo, logger, "X_AVM-DE_Speedtest")
{
    public KeyValuePair<AvmSpeedtestGetInfoResponse?, UPnPFault?>? AvmSpeedtestGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<AvmSpeedtestGetStatisticsResponse?, UPnPFault?>? AvmSpeedtestGetStatisticsResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => Task.WhenAll(GetAvmSpeedtestGetInfoAsync(), GetAvmSpeedtestGetStatisticsAsync()).Evaluate(ConfigureAwaitOptions.ContinueOnCapturedContext);

    private async Task GetAvmSpeedtestGetInfoAsync()
        => AvmSpeedtestGetInfoResponse = await ExecuteApiAsync(static q => q.AvmSpeedtestGetInfoAsync()).ConfigureAwait(true);

    private async Task GetAvmSpeedtestGetStatisticsAsync()
        => AvmSpeedtestGetStatisticsResponse = await ExecuteApiAsync(static q => q.AvmSpeedtestGetStatisticsAsync()).ConfigureAwait(true);
}
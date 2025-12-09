namespace RS.Fritz.Manager.UI;

internal sealed class WanFiberViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<WanFiberViewModel> logger)
    : WanAccessTypeAwareFritzServiceViewModel(deviceLoginInfo, logger, WanAccessType.Ethernet, "X_AVM-DE_WANFiber")
{
    public KeyValuePair<WanFiberGetInfoResponse?, UPnPFault?>? WanFiberGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanFiberGetInfoGponResponse?, UPnPFault?>? WanFiberGetInfoGponResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanFiberGetStatisticsResponse?, UPnPFault?>? WanFiberGetStatisticsResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => Task.WhenAll(
            GetWanFiberGetInfoAsync(),
            GetWanFiberGetInfoGponAsync(),
            GetWanFiberGetStatisticsAsync())
            .Evaluate(ConfigureAwaitOptions.ContinueOnCapturedContext);

    private async Task GetWanFiberGetInfoAsync()
        => WanFiberGetInfoResponse = await ExecuteApiAsync(static q => q.WanFiberGetInfoAsync()).ConfigureAwait(true);

    private async Task GetWanFiberGetInfoGponAsync()
        => WanFiberGetInfoGponResponse = await ExecuteApiAsync(static q => q.WanFiberGetInfoGponAsync()).ConfigureAwait(true);

    private async Task GetWanFiberGetStatisticsAsync()
        => WanFiberGetStatisticsResponse = await ExecuteApiAsync(static q => q.WanFiberGetStatisticsAsync()).ConfigureAwait(true);
}
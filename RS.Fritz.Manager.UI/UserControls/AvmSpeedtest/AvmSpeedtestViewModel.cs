namespace RS.Fritz.Manager.UI;

internal sealed class AvmSpeedtestViewModel : FritzServiceViewModel
{
    private KeyValuePair<AvmSpeedtestGetInfoResponse?, UPnPFault?>? avmSpeedtestGetInfoResponse;

    public AvmSpeedtestViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "X_AVM-DE_Speedtest")
    {
    }

    public KeyValuePair<AvmSpeedtestGetInfoResponse?, UPnPFault?>? AvmSpeedtestGetInfoResponse
    {
        get => avmSpeedtestGetInfoResponse;
        private set { _ = SetProperty(ref avmSpeedtestGetInfoResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        AvmSpeedtestGetInfoResponse = await ExecuteApiAsync(q => q.AvmSpeedtestGetInfoAsync());
    }
}
namespace RS.Fritz.Manager.UI;

using System.Windows.Threading;
using CommunityToolkit.Mvvm.Messaging.Messages;

internal sealed class WanDslInterfaceConfigViewModel : WanAccessTypeAwareFritzServiceViewModel
{
    private readonly DispatcherTimer autoRefreshTimer;

    private bool autoRefresh;
    private KeyValuePair<WanDslInterfaceConfigGetDslDiagnoseInfoResponse?, UPnPFault?>? wanDslInterfaceConfigGetDslDiagnoseInfoResponse;
    private KeyValuePair<WanDslInterfaceConfigGetStatisticsTotalResponse?, UPnPFault?>? wanDslInterfaceConfigGetStatisticsTotalResponse;

    public WanDslInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanDslInterfaceConfigInfoViewModel wanDslInterfaceConfigInfoViewModel, WanDslInterfaceConfigDslInfoViewModel wanDslInterfaceConfigDslInfoViewModel)
        : base(deviceLoginInfo, logger, WanAccessType.Dsl, "WANDSLInterfaceConfig")
    {
        WanDslInterfaceConfigInfoViewModel = wanDslInterfaceConfigInfoViewModel;
        WanDslInterfaceConfigDslInfoViewModel = wanDslInterfaceConfigDslInfoViewModel;
        autoRefreshTimer = new()
        {
            Interval = TimeSpan.FromSeconds(3d)
        };
        autoRefreshTimer.Tick += AutoRefreshTimerTick;
    }

    public bool AutoRefresh
    {
        get => autoRefresh;
        set
        {
            if (SetProperty(ref autoRefresh, value))
            {
                if (value)
                    autoRefreshTimer.Start();
                else
                    autoRefreshTimer.Stop();
            }
        }
    }

    public KeyValuePair<WanDslInterfaceConfigGetDslDiagnoseInfoResponse?, UPnPFault?>? WanDslInterfaceConfigGetDslDiagnoseInfoResponse
    {
        get => wanDslInterfaceConfigGetDslDiagnoseInfoResponse;
        private set => _ = SetProperty(ref wanDslInterfaceConfigGetDslDiagnoseInfoResponse, value);
    }

    public KeyValuePair<WanDslInterfaceConfigGetStatisticsTotalResponse?, UPnPFault?>? WanDslInterfaceConfigGetStatisticsTotalResponse
    {
        get => wanDslInterfaceConfigGetStatisticsTotalResponse;
        private set => _ = SetProperty(ref wanDslInterfaceConfigGetStatisticsTotalResponse, value);
    }

    public WanDslInterfaceConfigInfoViewModel WanDslInterfaceConfigInfoViewModel { get; }

    public WanDslInterfaceConfigDslInfoViewModel WanDslInterfaceConfigDslInfoViewModel { get; }

    protected override void Receive(PropertyChangedMessage<bool> message)
    {
        base.Receive(message);

        if (message.Sender != DeviceLoginInfo)
            return;

        switch (message.PropertyName)
        {
            case nameof(DeviceLoginInfo.LoginInfoSet):
                {
                    if (!message.NewValue)
                        AutoRefresh = false;
                    break;
                }
        }
    }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(
            new[]
            {
                GetWanDslInterfaceConfigGetDslDiagnoseInfoAsync(),
                GetWanDslInterfaceConfigGetDslInfoAsync(),
                GetWanDslInterfaceConfigGetInfoAsync(),
                GetWanDslInterfaceConfigGetStatisticsTotalAsync()
            },
            true);
    }

    private async void AutoRefreshTimerTick(object? sender, EventArgs e)
    {
        try
        {
            if (CanExecuteDefaultCommand)
                await DefaultCommand.ExecuteAsync(false).ConfigureAwait(true);
        }
        catch (Exception ex)
        {
            AutoRefresh = false;

            Logger.ExceptionThrown(ex);
        }
    }

    private async Task GetWanDslInterfaceConfigGetDslDiagnoseInfoAsync()
        => WanDslInterfaceConfigGetDslDiagnoseInfoResponse = await ExecuteApiAsync(q => q.WanDslInterfaceConfigGetDslDiagnoseInfoAsync()).ConfigureAwait(true);

    private async Task GetWanDslInterfaceConfigGetDslInfoAsync()
        => WanDslInterfaceConfigDslInfoViewModel.WanDslInterfaceConfigGetDslInfoResponse = await ExecuteApiAsync(q => q.WanDslInterfaceConfigGetDslInfoAsync()).ConfigureAwait(true);

    private async Task GetWanDslInterfaceConfigGetInfoAsync()
        => WanDslInterfaceConfigInfoViewModel.WanDslInterfaceConfigGetInfoResponse = await ExecuteApiAsync(q => q.WanDslInterfaceConfigGetInfoAsync()).ConfigureAwait(true);

    private async Task GetWanDslInterfaceConfigGetStatisticsTotalAsync()
        => WanDslInterfaceConfigGetStatisticsTotalResponse = await ExecuteApiAsync(q => q.WanDslInterfaceConfigGetStatisticsTotalAsync()).ConfigureAwait(true);
}
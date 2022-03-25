namespace RS.Fritz.Manager.UI;

using System.Windows.Threading;
using CommunityToolkit.Mvvm.Messaging.Messages;

internal sealed class WanDslInterfaceConfigViewModel : WanAccessTypeAwareFritzServiceViewModel
{
    private readonly DispatcherTimer autoRefreshTimer;

    private bool autoRefresh;
    private WanDslInterfaceConfigGetDslDiagnoseInfoResponse? wanDslInterfaceConfigGetDslDiagnoseInfoResponse;
    private WanDslInterfaceConfigGetStatisticsTotalResponse? wanDslInterfaceConfigGetStatisticsTotalResponse;

    public WanDslInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger, WanDslInterfaceConfigInfoViewModel wanDslInterfaceConfigInfoViewModel, WanDslInterfaceConfigDslInfoViewModel wanDslInterfaceConfigDslInfoViewModel)
        : base(deviceLoginInfo, logger, WanAccessType.Dsl)
    {
        WanDslInterfaceConfigInfoViewModel = wanDslInterfaceConfigInfoViewModel;
        WanDslInterfaceConfigDslInfoViewModel = wanDslInterfaceConfigDslInfoViewModel;
        autoRefreshTimer = new DispatcherTimer
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

    public WanDslInterfaceConfigGetDslDiagnoseInfoResponse? WanDslInterfaceConfigGetDslDiagnoseInfoResponse
    {
        get => wanDslInterfaceConfigGetDslDiagnoseInfoResponse;
        private set { _ = SetProperty(ref wanDslInterfaceConfigGetDslDiagnoseInfoResponse, value); }
    }

    public WanDslInterfaceConfigGetStatisticsTotalResponse? WanDslInterfaceConfigGetStatisticsTotalResponse
    {
        get => wanDslInterfaceConfigGetStatisticsTotalResponse;
        private set { _ = SetProperty(ref wanDslInterfaceConfigGetStatisticsTotalResponse, value); }
    }

    public WanDslInterfaceConfigInfoViewModel WanDslInterfaceConfigInfoViewModel { get; }

    public WanDslInterfaceConfigDslInfoViewModel WanDslInterfaceConfigDslInfoViewModel { get; }

    public override void Receive(PropertyChangedMessage<bool> message)
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

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
                GetWanDslInterfaceConfigGetDslDiagnoseInfoAsync(),
                GetWanDslInterfaceConfigGetDslInfoAsync(),
                GetWanDslInterfaceConfigGetInfoAsync(),
                GetWanDslInterfaceConfigGetStatisticsTotalAsync()
            });
    }

    private async void AutoRefreshTimerTick(object? sender, EventArgs e)
    {
        if (CanExecuteDefaultCommand)
            await DefaultCommand.ExecuteAsync(false);
    }

    private async Task GetWanDslInterfaceConfigGetDslDiagnoseInfoAsync()
    {
        WanDslInterfaceConfigGetDslDiagnoseInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslInterfaceConfigGetDslDiagnoseInfoAsync();
    }

    private async Task GetWanDslInterfaceConfigGetDslInfoAsync()
    {
        WanDslInterfaceConfigDslInfoViewModel.WanDslInterfaceConfigGetDslInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslInterfaceConfigGetDslInfoAsync();
    }

    private async Task GetWanDslInterfaceConfigGetInfoAsync()
    {
        WanDslInterfaceConfigInfoViewModel.WanDslInterfaceConfigGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslInterfaceConfigGetInfoAsync();
    }

    private async Task GetWanDslInterfaceConfigGetStatisticsTotalAsync()
    {
        WanDslInterfaceConfigGetStatisticsTotalResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslInterfaceConfigGetStatisticsTotalAsync();
    }
}
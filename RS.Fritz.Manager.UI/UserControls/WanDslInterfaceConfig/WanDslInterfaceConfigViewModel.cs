namespace RS.Fritz.Manager.UI;

using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanDslInterfaceConfigViewModel : FritzServiceViewModel
{
    private readonly DispatcherTimer autoRefreshTimer;

    private bool autoRefresh;
    private WanDslInterfaceConfigGetDslDiagnoseInfoResponse? wanDslInterfaceConfigGetDslDiagnoseInfoResponse;
    private WanDslInterfaceConfigGetDslInfoResponse? wanDslInterfaceConfigGetDslInfoResponse;
    private WanDslInterfaceConfigGetStatisticsTotalResponse? wanDslInterfaceConfigGetStatisticsTotalResponse;

    public WanDslInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
        WanDslInterfaceConfigInfoControlViewModel = new WanDslInterfaceConfigInfoControlViewModel();
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

    public WanDslInterfaceConfigGetDslInfoResponse? WanDslInterfaceConfigGetDslInfoResponse
    {
        get => wanDslInterfaceConfigGetDslInfoResponse;
        private set { _ = SetProperty(ref wanDslInterfaceConfigGetDslInfoResponse, value); }
    }

    public WanDslInterfaceConfigInfoControlViewModel WanDslInterfaceConfigInfoControlViewModel { get; }

    public WanDslInterfaceConfigGetStatisticsTotalResponse? WanDslInterfaceConfigGetStatisticsTotalResponse
    {
        get => wanDslInterfaceConfigGetStatisticsTotalResponse;
        private set { _ = SetProperty(ref wanDslInterfaceConfigGetStatisticsTotalResponse, value); }
    }

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

    protected override async Task DoExecuteDefaultCommandAsync()
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
        WanDslInterfaceConfigGetDslInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslInterfaceConfigGetDslInfoAsync();
    }

    private async Task GetWanDslInterfaceConfigGetInfoAsync()
    {
        WanDslInterfaceConfigInfoControlViewModel.WanDslInterfaceConfigGetInfoResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslInterfaceConfigGetInfoAsync();
    }

    private async Task GetWanDslInterfaceConfigGetStatisticsTotalAsync()
    {
        WanDslInterfaceConfigGetStatisticsTotalResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanDslInterfaceConfigGetStatisticsTotalAsync();
    }
}
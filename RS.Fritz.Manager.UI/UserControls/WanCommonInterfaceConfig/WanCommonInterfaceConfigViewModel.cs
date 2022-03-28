namespace RS.Fritz.Manager.UI;

using System.Windows.Threading;

internal sealed class WanCommonInterfaceConfigViewModel : FritzServiceViewModel
{
    private readonly DispatcherTimer autoRefreshTimer;

    private bool autoRefresh;
    private WanCommonInterfaceConfigGetCommonLinkPropertiesResponse? wanCommonInterfaceConfigGetCommonLinkPropertiesResponse;
    private WanCommonInterfaceConfigGetTotalBytesReceivedResponse? wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
    private WanCommonInterfaceConfigGetTotalBytesSentResponse? wanCommonInterfaceConfigGetTotalBytesSentResponse;
    private WanCommonInterfaceConfigGetTotalPacketsReceivedResponse? wanCommonInterfaceConfigGetTotalPacketsReceivedResponse;
    private WanCommonInterfaceConfigGetTotalPacketsSentResponse? wanCommonInterfaceConfigGetTotalPacketsSentResponse;

    public WanCommonInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, WanCommonInterfaceConfigSetWanAccessTypeViewModel wanCommonInterfaceConfigSetWanAccessTypeViewModel, WanCommonInterfaceConfigGetOnlineMonitorViewModel wanCommonInterfaceConfigGetOnlineMonitorViewModel, ILogger logger)
        : base(deviceLoginInfo, logger, "WANCommonInterfaceConfig")
    {
        WanCommonInterfaceConfigSetWanAccessTypeViewModel = wanCommonInterfaceConfigSetWanAccessTypeViewModel;
        WanCommonInterfaceConfigGetOnlineMonitorViewModel = wanCommonInterfaceConfigGetOnlineMonitorViewModel;
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

    public WanCommonInterfaceConfigSetWanAccessTypeViewModel WanCommonInterfaceConfigSetWanAccessTypeViewModel { get; }

    public WanCommonInterfaceConfigGetOnlineMonitorViewModel WanCommonInterfaceConfigGetOnlineMonitorViewModel { get; }

    public WanCommonInterfaceConfigGetTotalBytesReceivedResponse? WanCommonInterfaceConfigGetTotalBytesReceivedResponse
    {
        get => wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesReceivedResponse, value); }
    }

    public WanCommonInterfaceConfigGetTotalBytesSentResponse? WanCommonInterfaceConfigGetTotalBytesSentResponse
    {
        get => wanCommonInterfaceConfigGetTotalBytesSentResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesSentResponse, value); }
    }

    public WanCommonInterfaceConfigGetTotalPacketsReceivedResponse? WanCommonInterfaceConfigGetTotalPacketsReceivedResponse
    {
        get => wanCommonInterfaceConfigGetTotalPacketsReceivedResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalPacketsReceivedResponse, value); }
    }

    public WanCommonInterfaceConfigGetTotalPacketsSentResponse? WanCommonInterfaceConfigGetTotalPacketsSentResponse
    {
        get => wanCommonInterfaceConfigGetTotalPacketsSentResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalPacketsSentResponse, value); }
    }

    public WanCommonInterfaceConfigGetCommonLinkPropertiesResponse? WanCommonInterfaceConfigGetCommonLinkPropertiesResponse
    {
        get => wanCommonInterfaceConfigGetCommonLinkPropertiesResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetCommonLinkPropertiesResponse, value); }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        await API.TaskExtensions.WhenAllSafe(new[]
            {
               GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync(),
               GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync(),
               GetWanCommonInterfaceConfigGetTotalBytesSentAsync(),
               GetWanCommonInterfaceConfigGetTotalPacketsReceivedAsync(),
               GetWanCommonInterfaceConfigGetTotalPacketsSentAsync(),
               GetWanCommonInterfaceConfigGetOnlineMonitorAsync()
            });
    }

    private async void AutoRefreshTimerTick(object? sender, EventArgs e)
    {
        try
        {
            if (CanExecuteDefaultCommand)
                await DefaultCommand.ExecuteAsync(false);
        }
        catch (Exception ex)
        {
            AutoRefresh = false;

            Logger.ExceptionThrown(ex);
        }
    }

    private async Task GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync()
    {
        WanCommonInterfaceConfigGetCommonLinkPropertiesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync();
    }

    private async Task GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync()
    {
        WanCommonInterfaceConfigGetTotalBytesReceivedResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanCommonInterfaceConfigGetTotalBytesReceivedAsync();
    }

    private async Task GetWanCommonInterfaceConfigGetTotalBytesSentAsync()
    {
        WanCommonInterfaceConfigGetTotalBytesSentResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanCommonInterfaceConfigGetTotalBytesSentAsync();
    }

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsReceivedAsync()
    {
        WanCommonInterfaceConfigGetTotalPacketsReceivedResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanCommonInterfaceConfigGetTotalPacketsReceivedAsync();
    }

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsSentAsync()
    {
        WanCommonInterfaceConfigGetTotalPacketsSentResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanCommonInterfaceConfigGetTotalPacketsSentAsync();
    }

    private async Task GetWanCommonInterfaceConfigGetOnlineMonitorAsync()
    {
        WanCommonInterfaceConfigGetOnlineMonitorViewModel.WanCommonInterfaceConfigGetOnlineMonitorResponse = await DeviceLoginInfo.InternetGatewayDevice!.ApiDevice.WanCommonInterfaceConfigGetOnlineMonitorAsync(0);
    }
}
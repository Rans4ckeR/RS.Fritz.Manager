namespace RS.Fritz.Manager.UI;

using System.Windows.Threading;

internal sealed class WanCommonInterfaceConfigViewModel : FritzServiceViewModel
{
    private readonly DispatcherTimer autoRefreshTimer;

    private bool autoRefresh;
    private KeyValuePair<WanCommonInterfaceConfigGetTotalBytesReceivedResponse?, UPnPFault?>? wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
    private KeyValuePair<WanCommonInterfaceConfigGetTotalBytesSentResponse?, UPnPFault?>? wanCommonInterfaceConfigGetTotalBytesSentResponse;
    private KeyValuePair<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse?, UPnPFault?>? wanCommonInterfaceConfigGetTotalPacketsReceivedResponse;
    private KeyValuePair<WanCommonInterfaceConfigGetTotalPacketsSentResponse?, UPnPFault?>? wanCommonInterfaceConfigGetTotalPacketsSentResponse;
    private KeyValuePair<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse?, UPnPFault?>? wanCommonInterfaceConfigGetCommonLinkPropertiesResponse;

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

    public KeyValuePair<WanCommonInterfaceConfigGetTotalBytesReceivedResponse?, UPnPFault?>? WanCommonInterfaceConfigGetTotalBytesReceivedResponse
    {
        get => wanCommonInterfaceConfigGetTotalBytesReceivedResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesReceivedResponse, value); }
    }

    public KeyValuePair<WanCommonInterfaceConfigGetTotalBytesSentResponse?, UPnPFault?>? WanCommonInterfaceConfigGetTotalBytesSentResponse
    {
        get => wanCommonInterfaceConfigGetTotalBytesSentResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalBytesSentResponse, value); }
    }

    public KeyValuePair<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse?, UPnPFault?>? WanCommonInterfaceConfigGetTotalPacketsReceivedResponse
    {
        get => wanCommonInterfaceConfigGetTotalPacketsReceivedResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalPacketsReceivedResponse, value); }
    }

    public KeyValuePair<WanCommonInterfaceConfigGetTotalPacketsSentResponse?, UPnPFault?>? WanCommonInterfaceConfigGetTotalPacketsSentResponse
    {
        get => wanCommonInterfaceConfigGetTotalPacketsSentResponse;
        private set { _ = SetProperty(ref wanCommonInterfaceConfigGetTotalPacketsSentResponse, value); }
    }

    public KeyValuePair<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse?, UPnPFault?>? WanCommonInterfaceConfigGetCommonLinkPropertiesResponse
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
        WanCommonInterfaceConfigGetCommonLinkPropertiesResponse = await ExecuteApiAsync(q => q.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync());
    }

    private async Task GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync()
    {
        WanCommonInterfaceConfigGetTotalBytesReceivedResponse = await ExecuteApiAsync(q => q.WanCommonInterfaceConfigGetTotalBytesReceivedAsync());
    }

    private async Task GetWanCommonInterfaceConfigGetTotalBytesSentAsync()
    {
        WanCommonInterfaceConfigGetTotalBytesSentResponse = await ExecuteApiAsync(q => q.WanCommonInterfaceConfigGetTotalBytesSentAsync());
    }

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsReceivedAsync()
    {
        WanCommonInterfaceConfigGetTotalPacketsReceivedResponse = await ExecuteApiAsync(q => q.WanCommonInterfaceConfigGetTotalPacketsReceivedAsync());
    }

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsSentAsync()
    {
        WanCommonInterfaceConfigGetTotalPacketsSentResponse = await ExecuteApiAsync(q => q.WanCommonInterfaceConfigGetTotalPacketsSentAsync());
    }

    private async Task GetWanCommonInterfaceConfigGetOnlineMonitorAsync()
    {
        WanCommonInterfaceConfigGetOnlineMonitorViewModel.WanCommonInterfaceConfigGetOnlineMonitorResponse = await ExecuteApiAsync(q => q.WanCommonInterfaceConfigGetOnlineMonitorAsync(new WanCommonInterfaceConfigGetOnlineMonitorRequest(0)));
    }
}
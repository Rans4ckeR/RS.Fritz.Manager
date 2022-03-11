namespace RS.Fritz.Manager.UI;

using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

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
        : base(deviceLoginInfo, logger)
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

    protected override async Task DoExecuteDefaultCommandAsync()
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
        if (CanExecuteDefaultCommand)
            await DefaultCommand.ExecuteAsync(false);
    }

    private async Task GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync()
    {
        WanCommonInterfaceConfigGetCommonLinkPropertiesResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync(d));
    }

    private async Task GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync()
    {
        WanCommonInterfaceConfigGetTotalBytesReceivedResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalBytesReceivedAsync(d));
    }

    private async Task GetWanCommonInterfaceConfigGetTotalBytesSentAsync()
    {
        WanCommonInterfaceConfigGetTotalBytesSentResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalBytesSentAsync(d));
    }

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsReceivedAsync()
    {
        WanCommonInterfaceConfigGetTotalPacketsReceivedResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalPacketsReceivedAsync(d));
    }

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsSentAsync()
    {
        WanCommonInterfaceConfigGetTotalPacketsSentResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetTotalPacketsSentAsync(d));
    }

    private async Task GetWanCommonInterfaceConfigGetOnlineMonitorAsync()
    {
        WanCommonInterfaceConfigGetOnlineMonitorViewModel.WanCommonInterfaceConfigGetOnlineMonitorResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetOnlineMonitorAsync(d, 0));
    }
}
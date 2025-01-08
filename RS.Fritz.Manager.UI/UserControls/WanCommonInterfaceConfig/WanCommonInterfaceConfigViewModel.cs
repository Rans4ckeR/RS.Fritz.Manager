using System.Windows.Threading;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace RS.Fritz.Manager.UI;

internal sealed class WanCommonInterfaceConfigViewModel : FritzServiceViewModel
{
    private readonly DispatcherTimer autoRefreshTimer;

    public WanCommonInterfaceConfigViewModel(DeviceLoginInfo deviceLoginInfo, WanCommonInterfaceConfigSetWanAccessTypeViewModel wanCommonInterfaceConfigSetWanAccessTypeViewModel, WanCommonInterfaceConfigGetOnlineMonitorViewModel wanCommonInterfaceConfigGetOnlineMonitorViewModel, ILogger<WanCommonInterfaceConfigViewModel> logger)
        : base(deviceLoginInfo, logger, "WANCommonInterfaceConfig")
    {
        WanCommonInterfaceConfigSetWanAccessTypeViewModel = wanCommonInterfaceConfigSetWanAccessTypeViewModel;
        WanCommonInterfaceConfigGetOnlineMonitorViewModel = wanCommonInterfaceConfigGetOnlineMonitorViewModel;
        autoRefreshTimer = new()
        {
            Interval = TimeSpan.FromSeconds(3d)
        };
        autoRefreshTimer.Tick += AutoRefreshTimerTick;
    }

    public bool AutoRefresh
    {
        get;
        set
        {
            if (!SetProperty(ref field, value))
                return;

            if (value)
                autoRefreshTimer.Start();
            else
                autoRefreshTimer.Stop();
        }
    }

    public WanCommonInterfaceConfigSetWanAccessTypeViewModel WanCommonInterfaceConfigSetWanAccessTypeViewModel { get; }

    public WanCommonInterfaceConfigGetOnlineMonitorViewModel WanCommonInterfaceConfigGetOnlineMonitorViewModel { get; }

    public KeyValuePair<WanCommonInterfaceConfigGetTotalBytesReceivedResponse?, UPnPFault?>? WanCommonInterfaceConfigGetTotalBytesReceivedResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanCommonInterfaceConfigGetTotalBytesSentResponse?, UPnPFault?>? WanCommonInterfaceConfigGetTotalBytesSentResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanCommonInterfaceConfigGetTotalPacketsReceivedResponse?, UPnPFault?>? WanCommonInterfaceConfigGetTotalPacketsReceivedResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanCommonInterfaceConfigGetTotalPacketsSentResponse?, UPnPFault?>? WanCommonInterfaceConfigGetTotalPacketsSentResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanCommonInterfaceConfigGetCommonLinkPropertiesResponse?, UPnPFault?>? WanCommonInterfaceConfigGetCommonLinkPropertiesResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

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
        => Task.WhenAll(
                GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync(),
                GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync(),
                GetWanCommonInterfaceConfigGetTotalBytesSentAsync(),
                GetWanCommonInterfaceConfigGetTotalPacketsReceivedAsync(),
                GetWanCommonInterfaceConfigGetTotalPacketsSentAsync(),
                GetWanCommonInterfaceConfigGetOnlineMonitorAsync())
            .Evaluate(ConfigureAwaitOptions.ContinueOnCapturedContext);

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

    private async Task GetWanCommonInterfaceConfigGetCommonLinkPropertiesAsync()
        => WanCommonInterfaceConfigGetCommonLinkPropertiesResponse = await ExecuteApiAsync(static q => q.WanCommonInterfaceConfigGetCommonLinkPropertiesAsync()).ConfigureAwait(true);

    private async Task GetWanCommonInterfaceConfigGetTotalBytesReceivedAsync()
        => WanCommonInterfaceConfigGetTotalBytesReceivedResponse = await ExecuteApiAsync(static q => q.WanCommonInterfaceConfigGetTotalBytesReceivedAsync()).ConfigureAwait(true);

    private async Task GetWanCommonInterfaceConfigGetTotalBytesSentAsync()
        => WanCommonInterfaceConfigGetTotalBytesSentResponse = await ExecuteApiAsync(static q => q.WanCommonInterfaceConfigGetTotalBytesSentAsync()).ConfigureAwait(true);

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsReceivedAsync()
        => WanCommonInterfaceConfigGetTotalPacketsReceivedResponse = await ExecuteApiAsync(static q => q.WanCommonInterfaceConfigGetTotalPacketsReceivedAsync()).ConfigureAwait(true);

    private async Task GetWanCommonInterfaceConfigGetTotalPacketsSentAsync()
        => WanCommonInterfaceConfigGetTotalPacketsSentResponse = await ExecuteApiAsync(static q => q.WanCommonInterfaceConfigGetTotalPacketsSentAsync()).ConfigureAwait(true);

    private async Task GetWanCommonInterfaceConfigGetOnlineMonitorAsync()
        => WanCommonInterfaceConfigGetOnlineMonitorViewModel.WanCommonInterfaceConfigGetOnlineMonitorResponse = await ExecuteApiAsync(static q => q.WanCommonInterfaceConfigGetOnlineMonitorAsync(new(0))).ConfigureAwait(true);
}
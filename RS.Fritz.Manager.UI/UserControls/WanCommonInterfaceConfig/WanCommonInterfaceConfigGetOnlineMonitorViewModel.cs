namespace RS.Fritz.Manager.UI;

using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

internal sealed class WanCommonInterfaceConfigGetOnlineMonitorViewModel : FritzServiceViewModel
{
    private uint syncGroupIndex;
    private WanCommonInterfaceConfigGetOnlineMonitorResponse? wanCommonInterfaceConfigGetOnlineMonitorResponse;
    private List<uint>? downstreamInternetBps;
    private List<uint>? downstreamIpTvBps;
    private List<uint>? upstreamTotalBps;
    private List<uint>? upstreamRealTimeApplicationsBps;
    private List<uint>? upstreamPrioritizedApplicationsBps;
    private List<uint>? upstreamNormalApplicationsBps;
    private List<uint>? upstreamBackgroundApplicationsBps;
    private List<UIElement>? onlineMonitorDownstreamElements;
    private List<UIElement>? onlineMonitorUpstreamElements;

    public WanCommonInterfaceConfigGetOnlineMonitorViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
    }

    public uint SyncGroupIndex
    {
        get => syncGroupIndex;
        set
        {
            if (SetProperty(ref syncGroupIndex, value))
                DefaultCommand.NotifyCanExecuteChanged();
        }
    }

    public List<UIElement>? OnlineMonitorDownstreamElements
    {
        get => onlineMonitorDownstreamElements;
        private set { _ = SetProperty(ref onlineMonitorDownstreamElements, value); }
    }

    public List<UIElement>? OnlineMonitorUpstreamElements
    {
        get => onlineMonitorUpstreamElements;
        private set { _ = SetProperty(ref onlineMonitorUpstreamElements, value); }
    }

    public WanCommonInterfaceConfigGetOnlineMonitorResponse? WanCommonInterfaceConfigGetOnlineMonitorResponse
    {
        get => wanCommonInterfaceConfigGetOnlineMonitorResponse;
        set
        {
            _ = SetProperty(ref wanCommonInterfaceConfigGetOnlineMonitorResponse, value);

            downstreamInternetBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.DownstreamInternetBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            downstreamIpTvBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.DownstreamIpTvBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamTotalBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.UpstreamTotalBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamRealTimeApplicationsBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.UpstreamRealTimeApplicationsBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamPrioritizedApplicationsBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.UpstreamPrioritizedApplicationsBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamNormalApplicationsBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.UpstreamNormalApplicationsBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamBackgroundApplicationsBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.UpstreamBackgroundApplicationsBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();

            UpdateOnlineMonitorDownstreamElements();
            UpdateOnlineMonitorUpstreamElements();
        }
    }

    protected override async Task DoExecuteDefaultCommandAsync()
    {
        WanCommonInterfaceConfigGetOnlineMonitorResponse = await DeviceLoginInfo.InternetGatewayDevice!.ExecuteAsync((h, d) => h.WanCommonInterfaceConfigGetOnlineMonitorAsync(d, SyncGroupIndex));
    }

    protected override void FritzServiceViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        base.FritzServiceViewModelPropertyChanged(sender, e);

        switch (e.PropertyName)
        {
            case nameof(SyncGroupIndex):
                {
                    UpdateCanExecuteDefaultCommand();
                    break;
                }
        }
    }

    protected override bool GetCanExecuteDefaultCommand()
    {
        return base.GetCanExecuteDefaultCommand() && (WanCommonInterfaceConfigGetOnlineMonitorResponse is null || SyncGroupIndex < WanCommonInterfaceConfigGetOnlineMonitorResponse!.TotalNumberSyncGroups);
    }

    private static void CreateUiElements(double yScale, double xScale, uint min, uint range, List<UIElement> uiElements, List<uint> values, Brush brush)
    {
        for (int i = 1; i < values.Count; i++)
        {
            uint value = values[i];
            var line = new Line
            {
                X1 = (i - 2) * xScale,
                Y1 = (values[i - 1] - min) / (double)range * yScale,
                X2 = (i - 1) * xScale,
                Y2 = (value - min) / (double)range * yScale,
                Fill = brush,
                Stroke = brush
            };

            uiElements.Add(line);
        }
    }

    private void UpdateOnlineMonitorDownstreamElements()
    {
        const double yScale = 300d;
        const double xScale = 50d;
        var streamBps = downstreamInternetBps!.Concat(downstreamIpTvBps!).ToList();
        uint min = streamBps.Min();
        uint max = streamBps.Max();
        uint range = max - min;

        if (range == 0)
            range = 1;

        var uiElements = new List<UIElement>();

        CreateUiElements(yScale, xScale, min, range, uiElements, downstreamInternetBps!, Brushes.DarkViolet);
        CreateUiElements(yScale, xScale, min, range, uiElements, downstreamIpTvBps!, Brushes.Red);

        var labelMax = new Label { Content = max, Foreground = Brushes.LightGreen, LayoutTransform = new ScaleTransform { ScaleY = -1d } };
        var labelMin = new Label { Content = min, Foreground = Brushes.Orange, LayoutTransform = new ScaleTransform { ScaleY = -1d } };

        Canvas.SetLeft(labelMax, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMax, 0.5);
        Canvas.SetLeft(labelMin, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMin, 0.5 - 15d);
        uiElements.AddRange(new[] { labelMax, labelMin });

        OnlineMonitorDownstreamElements = uiElements;
    }

    private void UpdateOnlineMonitorUpstreamElements()
    {
        const double yScale = 300d;
        const double xScale = 50d;
        uint min = upstreamRealTimeApplicationsBps!.Concat(upstreamPrioritizedApplicationsBps!).Concat(upstreamNormalApplicationsBps!).Concat(upstreamBackgroundApplicationsBps!).Min();
        uint max = upstreamTotalBps!.Max();
        uint range = max - min;

        if (range == 0)
            range = 1;

        var uiElements = new List<UIElement>();

        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamRealTimeApplicationsBps!, Brushes.LightBlue);
        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamPrioritizedApplicationsBps!, Brushes.Yellow);
        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamNormalApplicationsBps!, Brushes.Green);
        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamBackgroundApplicationsBps!, Brushes.Blue);

        var labelMax = new Label { Content = max, Foreground = Brushes.LightGreen, LayoutTransform = new ScaleTransform { ScaleY = -1d } };
        var labelMin = new Label { Content = min, Foreground = Brushes.Orange, LayoutTransform = new ScaleTransform { ScaleY = -1d } };

        Canvas.SetLeft(labelMax, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMax, 0.5);
        Canvas.SetLeft(labelMin, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMin, 0.5 - 15d);
        uiElements.AddRange(new[] { labelMax, labelMin });

        OnlineMonitorUpstreamElements = uiElements;
    }
}
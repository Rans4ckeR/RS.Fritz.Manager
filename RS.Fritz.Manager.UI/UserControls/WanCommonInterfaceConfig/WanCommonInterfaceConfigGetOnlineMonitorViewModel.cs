using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RS.Fritz.Manager.UI;

internal sealed class WanCommonInterfaceConfigGetOnlineMonitorViewModel : FritzServiceViewModel
{
    private readonly Brush downstreamInternetBrush = Brushes.DarkViolet;
    private readonly Brush downstreamIpTvBrush = Brushes.Red;
    private readonly Brush maxBrush = Brushes.LightGreen;
    private readonly Brush minBrush = Brushes.Orange;
    private readonly Brush upstreamTotalBrush = Brushes.OrangeRed;
    private readonly Brush upstreamRealTimeApplicationsBrush = Brushes.LightBlue;
    private readonly Brush upstreamPrioritizedApplications = Brushes.Yellow;
    private readonly Brush upstreamNormalApplications = Brushes.Green;
    private readonly Brush upstreamBackgroundApplicationsBrush = Brushes.DodgerBlue;
    private readonly ScaleTransform scaleYTransform = new() { ScaleY = -1d };
    private readonly ScaleTransform scaleXyTransform = new() { ScaleX = 2d, ScaleY = -2d };

    private List<uint>? downstreamInternetBps;
    private List<uint>? downstreamIpTvBps;
    private List<uint>? upstreamTotalBps;
    private List<uint>? upstreamRealTimeApplicationsBps;
    private List<uint>? upstreamPrioritizedApplicationsBps;
    private List<uint>? upstreamNormalApplicationsBps;
    private List<uint>? upstreamBackgroundApplicationsBps;

    public WanCommonInterfaceConfigGetOnlineMonitorViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger)
    {
        scaleYTransform.Freeze();
        scaleXyTransform.Freeze();
        downstreamInternetBrush.Freeze();
        downstreamIpTvBrush.Freeze();
        maxBrush.Freeze();
        minBrush.Freeze();
        upstreamTotalBrush.Freeze();
        upstreamRealTimeApplicationsBrush.Freeze();
        upstreamPrioritizedApplications.Freeze();
        upstreamNormalApplications.Freeze();
        upstreamBackgroundApplicationsBrush.Freeze();
    }

    public uint SyncGroupIndex
    {
        get;
        set
        {
            if (SetProperty(ref field, value))
                UpdateAndNotifyCanExecuteDefaultCommand();
        }
    }

    public List<UIElement>? OnlineMonitorDownstreamElements
    {
        get;
        private set
        {
            if (!SetProperty(ref field, value))
                return;

            CurrentDownstreamInternetBps = downstreamInternetBps!.First();
            CurrentDownstreamIpTvBps = downstreamIpTvBps!.First();
            CurrentUpstreamTotalBps = upstreamTotalBps!.First();
            CurrentUpstreamRealTimeApplicationsBps = upstreamRealTimeApplicationsBps!.First();
            CurrentUpstreamPrioritizedApplicationsBps = upstreamPrioritizedApplicationsBps!.First();
            CurrentUpstreamNormalApplicationsBps = upstreamNormalApplicationsBps!.First();
            CurrentUpstreamBackgroundApplicationsBps = upstreamBackgroundApplicationsBps!.First();
        }
    }

    public List<UIElement>? OnlineMonitorUpstreamElements
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public uint? CurrentDownstreamInternetBps
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public uint? CurrentDownstreamIpTvBps
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public uint? CurrentUpstreamTotalBps
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public uint? CurrentUpstreamRealTimeApplicationsBps
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public uint? CurrentUpstreamPrioritizedApplicationsBps
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public uint? CurrentUpstreamNormalApplicationsBps
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public uint? CurrentUpstreamBackgroundApplicationsBps
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<WanCommonInterfaceConfigGetOnlineMonitorResponse?, UPnPFault?>? WanCommonInterfaceConfigGetOnlineMonitorResponse
    {
        get;
        set
        {
            _ = SetProperty(ref field, value);

            downstreamInternetBps =
            [
                .. field!.Value.Key!.Value.DownstreamInternetBps.Split(',')
                    .Select(q => uint.Parse(q, CultureInfo.InvariantCulture))
            ];
            downstreamIpTvBps =
            [
                .. field!.Value.Key!.Value.DownstreamIpTvBps.Split(',')
                    .Select(q => uint.Parse(q, CultureInfo.InvariantCulture))
            ];
            upstreamTotalBps =
            [
                .. field!.Value.Key!.Value.UpstreamTotalBps.Split(',')
                    .Select(q => uint.Parse(q, CultureInfo.InvariantCulture))
            ];
            upstreamRealTimeApplicationsBps =
            [
                .. field!.Value.Key!.Value.UpstreamRealTimeApplicationsBps.Split(',')
                    .Select(q => uint.Parse(q, CultureInfo.InvariantCulture))
            ];
            upstreamPrioritizedApplicationsBps =
            [
                .. field!.Value.Key!.Value.UpstreamPrioritizedApplicationsBps.Split(',')
                    .Select(q => uint.Parse(q, CultureInfo.InvariantCulture))
            ];
            upstreamNormalApplicationsBps =
            [
                .. field!.Value.Key!.Value.UpstreamNormalApplicationsBps.Split(',')
                    .Select(q => uint.Parse(q, CultureInfo.InvariantCulture))
            ];
            upstreamBackgroundApplicationsBps =
            [
                .. field!.Value.Key!.Value.UpstreamBackgroundApplicationsBps.Split(',')
                    .Select(q => uint.Parse(q, CultureInfo.InvariantCulture))
            ];

            UpdateOnlineMonitorDownstreamElements();
            UpdateOnlineMonitorUpstreamElements();
        }
    }

    protected override async ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => WanCommonInterfaceConfigGetOnlineMonitorResponse = await ExecuteApiAsync(q => q.WanCommonInterfaceConfigGetOnlineMonitorAsync(new(SyncGroupIndex))).ConfigureAwait(true);

    protected override bool GetCanExecuteDefaultCommand()
        => base.GetCanExecuteDefaultCommand() && (WanCommonInterfaceConfigGetOnlineMonitorResponse is null || SyncGroupIndex < WanCommonInterfaceConfigGetOnlineMonitorResponse!.Value.Key!.Value.TotalNumberSyncGroups);

    private static void CreateUiElements(double yScale, double xScale, uint min, uint range, List<UIElement> uiElements, List<uint> values, Brush brush)
    {
        for (int i = 1; i < values.Count; i++)
        {
            uint value = values[i];
            var line = new Line
            {
                X1 = xScale + ((i - 2) * xScale),
                Y1 = (values[i - 1] - min) / (double)range * yScale,
                X2 = xScale + ((i - 1) * xScale),
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

        if (range is 0)
            range = 1;

        var uiElements = new List<UIElement>();

        CreateUiElements(yScale, xScale, min, range, uiElements, downstreamInternetBps!, downstreamInternetBrush);
        CreateUiElements(yScale, xScale, min, range, uiElements, downstreamIpTvBps!, downstreamIpTvBrush);

        var labelMax = new Label { Content = max, Foreground = maxBrush, LayoutTransform = scaleYTransform };
        var labelMin = new Label { Content = min, Foreground = minBrush, LayoutTransform = scaleYTransform };
        var labelInternet = new Label { Content = "⬇️ Internet", Foreground = downstreamInternetBrush, LayoutTransform = scaleXyTransform };
        var labelIpTvInternet = new Label { Content = "⬇️ IPTV", Foreground = downstreamIpTvBrush, LayoutTransform = scaleXyTransform };

        Canvas.SetLeft(labelMax, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMax, 300);
        Canvas.SetLeft(labelMin, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMin, -15d);
        Canvas.SetLeft(labelInternet, 0d);
        Canvas.SetTop(labelInternet, 50d);
        Canvas.SetLeft(labelIpTvInternet, 0d);
        Canvas.SetTop(labelIpTvInternet, 25d);
        uiElements.AddRange([labelMax, labelMin, labelInternet, labelIpTvInternet]);

        OnlineMonitorDownstreamElements = uiElements;
    }

    private void UpdateOnlineMonitorUpstreamElements()
    {
        const double yScale = 300d;
        const double xScale = 50d;
        uint min = upstreamRealTimeApplicationsBps!.Concat(upstreamPrioritizedApplicationsBps!).Concat(upstreamNormalApplicationsBps!).Concat(upstreamBackgroundApplicationsBps!).Min();
        uint max = upstreamTotalBps!.Max();
        uint range = max - min;

        if (range is 0)
            range = 1;

        var uiElements = new List<UIElement>();

        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamTotalBps!, upstreamTotalBrush);
        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamRealTimeApplicationsBps!, upstreamRealTimeApplicationsBrush);
        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamPrioritizedApplicationsBps!, upstreamPrioritizedApplications);
        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamNormalApplicationsBps!, upstreamNormalApplications);
        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamBackgroundApplicationsBps!, upstreamBackgroundApplicationsBrush);

        var labelMax = new Label { Content = max, Foreground = maxBrush, LayoutTransform = scaleYTransform };
        var labelMin = new Label { Content = min, Foreground = minBrush, LayoutTransform = scaleYTransform };
        var labelTotal = new Label { Content = "⬆️ Total", Foreground = upstreamTotalBrush, LayoutTransform = scaleXyTransform };
        var labelRealtime = new Label { Content = "⬆️ Realtime", Foreground = upstreamRealTimeApplicationsBrush, LayoutTransform = scaleXyTransform };
        var labelPrioritized = new Label { Content = "⬆️ Prioritized", Foreground = upstreamPrioritizedApplications, LayoutTransform = scaleXyTransform };
        var labelNormal = new Label { Content = "⬆️ Normal", Foreground = upstreamNormalApplications, LayoutTransform = scaleXyTransform };
        var labelBackground = new Label { Content = "⬆️ Background", Foreground = upstreamBackgroundApplicationsBrush, LayoutTransform = scaleXyTransform };

        Canvas.SetLeft(labelMax, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMax, 300);
        Canvas.SetLeft(labelMin, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMin, -15d);
        Canvas.SetLeft(labelTotal, 0d);
        Canvas.SetTop(labelTotal, 125d);
        Canvas.SetLeft(labelRealtime, 0d);
        Canvas.SetTop(labelRealtime, 100d);
        Canvas.SetLeft(labelPrioritized, 0d);
        Canvas.SetTop(labelPrioritized, 75d);
        Canvas.SetLeft(labelNormal, 0d);
        Canvas.SetTop(labelNormal, 50d);
        Canvas.SetLeft(labelBackground, 0d);
        Canvas.SetTop(labelBackground, 25d);
        uiElements.AddRange([labelMax, labelMin, labelTotal, labelRealtime, labelPrioritized, labelNormal, labelBackground]);

        OnlineMonitorUpstreamElements = uiElements;
    }
}
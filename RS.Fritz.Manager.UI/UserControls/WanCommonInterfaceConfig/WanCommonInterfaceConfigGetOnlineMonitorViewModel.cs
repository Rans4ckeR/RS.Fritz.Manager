namespace RS.Fritz.Manager.UI;

using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
    private uint? currentDownstreamInternetBps;
    private uint? currentDownstreamIpTvBps;
    private uint? currentUpstreamTotalBps;
    private uint? currentUpstreamRealTimeApplicationsBps;
    private uint? currentUpstreamPrioritizedApplicationsBps;
    private uint? currentUpstreamNormalApplicationsBps;
    private uint? currentUpstreamBackgroundApplicationsBps;
    private List<UIElement>? onlineMonitorUpstreamElements;

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
        private set
        {
            if (SetProperty(ref onlineMonitorDownstreamElements, value))
            {
                CurrentDownstreamInternetBps = downstreamInternetBps!.First();
                CurrentDownstreamIpTvBps = downstreamIpTvBps!.First();
                CurrentUpstreamTotalBps = upstreamTotalBps!.First();
                CurrentUpstreamRealTimeApplicationsBps = upstreamRealTimeApplicationsBps!.First();
                CurrentUpstreamPrioritizedApplicationsBps = upstreamPrioritizedApplicationsBps!.First();
                CurrentUpstreamNormalApplicationsBps = upstreamNormalApplicationsBps!.First();
                CurrentUpstreamBackgroundApplicationsBps = upstreamBackgroundApplicationsBps!.First();
            }
        }
    }

    public List<UIElement>? OnlineMonitorUpstreamElements
    {
        get => onlineMonitorUpstreamElements;
        private set { _ = SetProperty(ref onlineMonitorUpstreamElements, value); }
    }

    public uint? CurrentDownstreamInternetBps
    {
        get => currentDownstreamInternetBps;
        private set { _ = SetProperty(ref currentDownstreamInternetBps, value); }
    }

    public uint? CurrentDownstreamIpTvBps
    {
        get => currentDownstreamIpTvBps;
        private set { _ = SetProperty(ref currentDownstreamIpTvBps, value); }
    }

    public uint? CurrentUpstreamTotalBps
    {
        get => currentUpstreamTotalBps;
        private set { _ = SetProperty(ref currentUpstreamTotalBps, value); }
    }

    public uint? CurrentUpstreamRealTimeApplicationsBps
    {
        get => currentUpstreamRealTimeApplicationsBps;
        private set { _ = SetProperty(ref currentUpstreamRealTimeApplicationsBps, value); }
    }

    public uint? CurrentUpstreamPrioritizedApplicationsBps
    {
        get => currentUpstreamPrioritizedApplicationsBps;
        private set { _ = SetProperty(ref currentUpstreamPrioritizedApplicationsBps, value); }
    }

    public uint? CurrentUpstreamNormalApplicationsBps
    {
        get => currentUpstreamNormalApplicationsBps;
        private set { _ = SetProperty(ref currentUpstreamNormalApplicationsBps, value); }
    }

    public uint? CurrentUpstreamBackgroundApplicationsBps
    {
        get => currentUpstreamBackgroundApplicationsBps;
        private set { _ = SetProperty(ref currentUpstreamBackgroundApplicationsBps, value); }
    }

    public WanCommonInterfaceConfigGetOnlineMonitorResponse? WanCommonInterfaceConfigGetOnlineMonitorResponse
    {
        get => wanCommonInterfaceConfigGetOnlineMonitorResponse;
        set
        {
            _ = SetProperty(ref wanCommonInterfaceConfigGetOnlineMonitorResponse, value);

            downstreamInternetBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.Value.DownstreamInternetBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            downstreamIpTvBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.Value.DownstreamIpTvBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamTotalBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.Value.UpstreamTotalBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamRealTimeApplicationsBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.Value.UpstreamRealTimeApplicationsBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamPrioritizedApplicationsBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.Value.UpstreamPrioritizedApplicationsBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamNormalApplicationsBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.Value.UpstreamNormalApplicationsBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
            upstreamBackgroundApplicationsBps = wanCommonInterfaceConfigGetOnlineMonitorResponse!.Value.UpstreamBackgroundApplicationsBps.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();

            UpdateOnlineMonitorDownstreamElements();
            UpdateOnlineMonitorUpstreamElements();
        }
    }

    protected override async Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        WanCommonInterfaceConfigGetOnlineMonitorResponse = await ExecuteApiAsync(q => q.WanCommonInterfaceConfigGetOnlineMonitorAsync(SyncGroupIndex));
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
        return base.GetCanExecuteDefaultCommand() && (WanCommonInterfaceConfigGetOnlineMonitorResponse is null || SyncGroupIndex < WanCommonInterfaceConfigGetOnlineMonitorResponse!.Value.TotalNumberSyncGroups);
    }

    private static void CreateUiElements(double yScale, double xScale, uint min, uint range, ICollection<UIElement> uiElements, IReadOnlyList<uint> values, Brush brush)
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

        if (range == 0)
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
        uiElements.AddRange(new[] { labelMax, labelMin, labelInternet, labelIpTvInternet });

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
        uiElements.AddRange(new[] { labelMax, labelMin, labelTotal, labelRealtime, labelPrioritized, labelNormal, labelBackground });

        OnlineMonitorUpstreamElements = uiElements;
    }
}
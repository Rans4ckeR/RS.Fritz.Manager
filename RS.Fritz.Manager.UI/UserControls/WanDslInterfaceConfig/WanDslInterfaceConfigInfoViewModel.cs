namespace RS.Fritz.Manager.UI;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;

internal sealed class WanDslInterfaceConfigInfoViewModel : ObservableObject
{
    private readonly Brush maxBrush = Brushes.LightGreen;
    private readonly Brush minBrush = Brushes.Orange;
    private readonly Brush lineBrush = Brushes.Green;
    private readonly ScaleTransform scaleYTransform = new() { ScaleY = -1d };
    private readonly List<WanDslInterfaceConfigGetInfoResponse> wanDslInterfaceConfigGetInfoResponses = [];

    private KeyValuePair<WanDslInterfaceConfigGetInfoResponse?, UPnPFault?>? wanDslInterfaceConfigGetInfoResponse;
    private List<UIElement>? downstreamMaxRateHistory;
    private List<UIElement>? upstreamCurrRateHistory;
    private List<UIElement>? downstreamCurrRateHistory;
    private List<UIElement>? upstreamMaxRateHistory;
    private List<UIElement>? downstreamNoiseMarginHistory;
    private List<UIElement>? upstreamAttenuationHistory;
    private List<UIElement>? downstreamAttenuationHistory;
    private List<UIElement>? upstreamPowerHistory;
    private List<UIElement>? downstreamPowerHistory;

    public WanDslInterfaceConfigInfoViewModel()
    {
        UpstreamCurrRateHistory = [];
        DownstreamCurrRateHistory = [];
        UpstreamMaxRateHistory = [];
        DownstreamMaxRateHistory = [];
        UpstreamNoiseMarginHistory = [];
        DownstreamNoiseMarginHistory = [];
        UpstreamAttenuationHistory = [];
        DownstreamAttenuationHistory = [];
        UpstreamPowerHistory = [];
        DownstreamPowerHistory = [];

        maxBrush.Freeze();
        minBrush.Freeze();
        lineBrush.Freeze();
        scaleYTransform.Freeze();
    }

    public KeyValuePair<WanDslInterfaceConfigGetInfoResponse?, UPnPFault?>? WanDslInterfaceConfigGetInfoResponse
    {
        get => wanDslInterfaceConfigGetInfoResponse;
        set
        {
            wanDslInterfaceConfigGetInfoResponses.Add(value!.Value.Key!.Value);

            if (wanDslInterfaceConfigGetInfoResponses.Count > 1)
            {
                UpstreamCurrRateHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => (uint)(q.UpstreamCurrRate < 0 ? 0 : q.UpstreamCurrRate)).ToList());
                DownstreamCurrRateHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => q.DownstreamCurrRate).ToList());
                UpstreamMaxRateHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => q.UpstreamMaxRate).ToList());
                DownstreamMaxRateHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => q.DownstreamMaxRate).ToList());
                UpstreamNoiseMarginHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => q.UpstreamNoiseMargin).ToList());
                DownstreamNoiseMarginHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => q.DownstreamNoiseMargin).ToList());
                UpstreamAttenuationHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => q.UpstreamAttenuation).ToList());
                DownstreamAttenuationHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => q.DownstreamAttenuation).ToList());
                UpstreamPowerHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => (uint)q.UpstreamPower).ToList());
                DownstreamPowerHistory = UpdateHistory(wanDslInterfaceConfigGetInfoResponses.Select(q => (uint)q.DownstreamPower).ToList());
            }

            _ = SetProperty(ref wanDslInterfaceConfigGetInfoResponse, value);
        }
    }

    public List<UIElement>? UpstreamCurrRateHistory
    {
        get => upstreamCurrRateHistory;
        private set => _ = SetProperty(ref upstreamCurrRateHistory, value);
    }

    public List<UIElement>? DownstreamCurrRateHistory
    {
        get => downstreamCurrRateHistory;
        private set => _ = SetProperty(ref downstreamCurrRateHistory, value);
    }

    public List<UIElement>? UpstreamMaxRateHistory
    {
        get => upstreamMaxRateHistory;
        private set => _ = SetProperty(ref upstreamMaxRateHistory, value);
    }

    public List<UIElement>? DownstreamMaxRateHistory
    {
        get => downstreamMaxRateHistory;
        private set => _ = SetProperty(ref downstreamMaxRateHistory, value);
    }

    public List<UIElement>? UpstreamNoiseMarginHistory
    {
        get => upstreamMaxRateHistory;
        private set => _ = SetProperty(ref upstreamMaxRateHistory, value);
    }

    public List<UIElement>? DownstreamNoiseMarginHistory
    {
        get => downstreamNoiseMarginHistory;
        private set => _ = SetProperty(ref downstreamNoiseMarginHistory, value);
    }

    public List<UIElement>? UpstreamAttenuationHistory
    {
        get => upstreamAttenuationHistory;
        private set => _ = SetProperty(ref upstreamAttenuationHistory, value);
    }

    public List<UIElement>? DownstreamAttenuationHistory
    {
        get => downstreamAttenuationHistory;
        private set => _ = SetProperty(ref downstreamAttenuationHistory, value);
    }

    public List<UIElement>? UpstreamPowerHistory
    {
        get => upstreamPowerHistory;
        private set => _ = SetProperty(ref upstreamPowerHistory, value);
    }

    public List<UIElement>? DownstreamPowerHistory
    {
        get => downstreamPowerHistory;
        private set => _ = SetProperty(ref downstreamPowerHistory, value);
    }

    private List<UIElement> UpdateHistory(List<uint> values)
    {
        const double yScale = 30d;
        const double xScale = 5d;
        const int xLimit = 100;
        int startIndex = values.Count > xLimit ? values.Count - xLimit : 1;
        uint min = values.Skip(startIndex - 1).Min();
        uint max = values.Skip(startIndex - 1).Max();
        uint labelMinValue = values.Min();
        uint labelMaxValue = values.Max();
        uint range = max - min;

        if (range is 0)
            range = 1;

        var uiElements = new List<UIElement>();

        for (int i = startIndex; i < values.Count; i++)
        {
            uint value = values[i];
            var line = new Line
            {
                X1 = (i - startIndex - 1) * xScale,
                Y1 = (values[i - 1] - min) / (double)range * yScale,
                X2 = (i - startIndex) * xScale,
                Y2 = (value - min) / (double)range * yScale,
                Fill = lineBrush,
                Stroke = lineBrush
            };

            uiElements.Add(line);
        }

        var labelMax = new Label { Content = labelMaxValue, Foreground = maxBrush, LayoutTransform = scaleYTransform };
        var labelMin = new Label { Content = labelMinValue, Foreground = minBrush, LayoutTransform = scaleYTransform };

        Canvas.SetLeft(labelMax, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMax, 0.5);
        Canvas.SetLeft(labelMin, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMin, 0.5 - 15d);
        uiElements.AddRange([labelMax, labelMin]);

        return uiElements;
    }
}
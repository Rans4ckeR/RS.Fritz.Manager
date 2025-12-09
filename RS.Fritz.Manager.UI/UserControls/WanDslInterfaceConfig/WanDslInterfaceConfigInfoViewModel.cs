using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RS.Fritz.Manager.UI;

internal sealed class WanDslInterfaceConfigInfoViewModel : ObservableObject
{
    private readonly Brush maxBrush = Brushes.LightGreen;
    private readonly Brush minBrush = Brushes.Orange;
    private readonly Brush lineBrush = Brushes.Green;
    private readonly ScaleTransform scaleYTransform = new() { ScaleY = -1d };
    private readonly List<WanDslInterfaceConfigGetInfoResponse> wanDslInterfaceConfigGetInfoResponses = [];

    private List<UIElement>? upstreamMaxRateHistory;

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
        get;
        set
        {
            wanDslInterfaceConfigGetInfoResponses.Add(value!.Value.Key!.Value);

            if (wanDslInterfaceConfigGetInfoResponses.Count > 1)
            {
                UpstreamCurrRateHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.UpstreamCurrRate)]);
                DownstreamCurrRateHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.DownstreamCurrRate)]);
                UpstreamMaxRateHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.UpstreamMaxRate)]);
                DownstreamMaxRateHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.DownstreamMaxRate)]);
                UpstreamNoiseMarginHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.UpstreamNoiseMargin)]);
                DownstreamNoiseMarginHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.DownstreamNoiseMargin)]);
                UpstreamAttenuationHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.UpstreamAttenuation)]);
                DownstreamAttenuationHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.DownstreamAttenuation)]);
                UpstreamPowerHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.UpstreamPower)]);
                DownstreamPowerHistory = UpdateHistory([.. wanDslInterfaceConfigGetInfoResponses.Select(static q => q.DownstreamPower)]);
            }

            _ = SetProperty(ref field, value);
        }
    }

    public List<UIElement>? UpstreamCurrRateHistory
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public List<UIElement>? DownstreamCurrRateHistory
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public List<UIElement>? UpstreamMaxRateHistory
    {
        get => upstreamMaxRateHistory;
        private set => _ = SetProperty(ref upstreamMaxRateHistory, value);
    }

    public List<UIElement>? DownstreamMaxRateHistory
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public List<UIElement>? UpstreamNoiseMarginHistory
    {
        get => upstreamMaxRateHistory;
        private set => _ = SetProperty(ref upstreamMaxRateHistory, value);
    }

    public List<UIElement>? DownstreamNoiseMarginHistory
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public List<UIElement>? UpstreamAttenuationHistory
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public List<UIElement>? DownstreamAttenuationHistory
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public List<UIElement>? UpstreamPowerHistory
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public List<UIElement>? DownstreamPowerHistory
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    private List<UIElement> UpdateHistory(List<int> values)
    {
        const double yScale = 30d;
        const double xScale = 5d;
        const int xLimit = 100;
        int startIndex = values.Count > xLimit ? values.Count - xLimit : 1;
        int min = values.Skip(startIndex - 1).Min();
        int max = values.Skip(startIndex - 1).Max();
        int labelMinValue = values.Min();
        int labelMaxValue = values.Max();
        int range = max - min;

        if (range is 0)
            range = 1;

        List<UIElement> uiElements = [];

        for (int i = startIndex; i < values.Count; i++)
        {
            int value = values[i];
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

        return [.. uiElements, labelMax, labelMin];
    }
}
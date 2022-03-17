namespace RS.Fritz.Manager.UI;

using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;
using RS.Fritz.Manager.API;

internal sealed class WanDslInterfaceConfigDslInfoViewModel : ObservableObject
{
    private readonly Brush maxBrush = Brushes.LightGreen;
    private readonly Brush minBrush = Brushes.Orange;
    private readonly Brush lineBrush = Brushes.Green;
    private readonly ScaleTransform scaleYTransform = new() { ScaleY = -1d };

    private WanDslInterfaceConfigGetDslInfoResponse? wanDslInterfaceConfigGetDslInfoResponse;
    private List<UIElement>? downstreamSnrElements;

    public WanDslInterfaceConfigDslInfoViewModel()
    {
        DownstreamSnrElements = new List<UIElement>();

        maxBrush.Freeze();
        minBrush.Freeze();
        lineBrush.Freeze();
        scaleYTransform.Freeze();
    }

    public WanDslInterfaceConfigGetDslInfoResponse? WanDslInterfaceConfigGetDslInfoResponse
    {
        get => wanDslInterfaceConfigGetDslInfoResponse;
        set
        {
            if (SetProperty(ref wanDslInterfaceConfigGetDslInfoResponse, value))
                UpdateDownstreamSnrElements();
        }
    }

    public List<UIElement>? DownstreamSnrElements
    {
        get => downstreamSnrElements;
        private set => _ = SetProperty(ref downstreamSnrElements, value);
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

    private void UpdateDownstreamSnrElements()
    {
        const double yScale = 200d;
        const double xScale = 2d;
        var downstreamSnrValues = WanDslInterfaceConfigGetDslInfoResponse!.SNRpsds.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
        uint min = downstreamSnrValues.Min();
        uint max = downstreamSnrValues.Max();
        uint range = max - min;

        if (range == 0)
            range = 1;

        var uiElements = new List<UIElement>();

        CreateUiElements(yScale, xScale, min, range, uiElements, downstreamSnrValues!, lineBrush);

        var labelMax = new Label { Content = max, Foreground = maxBrush, LayoutTransform = scaleYTransform };
        var labelMin = new Label { Content = min, Foreground = minBrush, LayoutTransform = scaleYTransform };

        Canvas.SetLeft(labelMax, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMax, 200);
        Canvas.SetLeft(labelMin, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMin, -15d);
        uiElements.AddRange(new[] { labelMax, labelMin });

        DownstreamSnrElements = uiElements;
    }
}
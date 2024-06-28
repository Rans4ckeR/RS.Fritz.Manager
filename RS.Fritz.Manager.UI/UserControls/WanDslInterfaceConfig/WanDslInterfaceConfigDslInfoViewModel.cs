namespace RS.Fritz.Manager.UI;

using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using CommunityToolkit.Mvvm.ComponentModel;

internal sealed class WanDslInterfaceConfigDslInfoViewModel : ObservableObject
{
    private readonly Brush maxBrush = Brushes.LightGreen;
    private readonly Brush minBrush = Brushes.Orange;
    private readonly Brush downstreamLineBrush = Brushes.Green;
    private readonly Brush upstreamLineBrush = Brushes.Yellow;
    private readonly ScaleTransform scaleYTransform = new() { ScaleY = -1d };

    private KeyValuePair<WanDslInterfaceConfigGetDslInfoResponse?, UPnPFault?>? wanDslInterfaceConfigGetDslInfoResponse;
    private List<UIElement>? downstreamSnrElements;

    public WanDslInterfaceConfigDslInfoViewModel()
    {
        DownstreamSnrElements = [];

        maxBrush.Freeze();
        minBrush.Freeze();
        downstreamLineBrush.Freeze();
        upstreamLineBrush.Freeze();
        scaleYTransform.Freeze();
    }

    public KeyValuePair<WanDslInterfaceConfigGetDslInfoResponse?, UPnPFault?>? WanDslInterfaceConfigGetDslInfoResponse
    {
        get => wanDslInterfaceConfigGetDslInfoResponse;
        set
        {
            if (SetProperty(ref wanDslInterfaceConfigGetDslInfoResponse, value))
                UpdateSnrElements();
        }
    }

    public List<UIElement>? DownstreamSnrElements
    {
        get => downstreamSnrElements;
        private set => _ = SetProperty(ref downstreamSnrElements, value);
    }

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

    private void UpdateSnrElements()
    {
        const double yScale = 200d;
        const double xScale = 2d;
        var downstreamSnrValues = WanDslInterfaceConfigGetDslInfoResponse!.Value.Key!.Value.SnrPsDs.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
        var upstreamSnrValues = WanDslInterfaceConfigGetDslInfoResponse!.Value.Key!.Value.SnrPsUs.Split(',').Select(q => uint.Parse(q, CultureInfo.InvariantCulture)).ToList();
        var snrValues = downstreamSnrValues.Concat(upstreamSnrValues).ToList();
        uint min = snrValues.Min();
        uint max = snrValues.Max();
        uint range = max - min;

        if (range is 0)
            range = 1;

        var uiElements = new List<UIElement>();

        CreateUiElements(yScale, xScale, min, range, uiElements, downstreamSnrValues, downstreamLineBrush);
        CreateUiElements(yScale, xScale, min, range, uiElements, upstreamSnrValues, upstreamLineBrush);

        var labelMax = new Label { Content = max, Foreground = maxBrush, LayoutTransform = scaleYTransform };
        var labelMin = new Label { Content = min, Foreground = minBrush, LayoutTransform = scaleYTransform };

        Canvas.SetLeft(labelMax, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMax, 200);
        Canvas.SetLeft(labelMin, uiElements.OfType<Line>().Last().X2);
        Canvas.SetTop(labelMin, -15d);
        uiElements.AddRange([labelMax, labelMin]);

        DownstreamSnrElements = uiElements;
    }
}
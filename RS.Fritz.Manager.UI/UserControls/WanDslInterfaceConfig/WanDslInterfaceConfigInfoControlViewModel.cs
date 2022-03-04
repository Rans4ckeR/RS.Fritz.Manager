namespace RS.Fritz.Manager.UI
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    using CommunityToolkit.Mvvm.ComponentModel;
    using RS.Fritz.Manager.API;

    internal sealed class WanDslInterfaceConfigInfoControlViewModel : ObservableObject
    {
        private WanDslInterfaceConfigGetInfoResponse? wanDslInterfaceConfigGetInfoResponse;
        private List<UIElement>? downstreamMaxRateHistory;
        private List<UIElement>? upstreamCurrRateHistory;
        private List<UIElement>? downstreamCurrRateHistory;
        private List<UIElement>? upstreamMaxRateHistory;
        private List<UIElement>? downstreamNoiseMarginHistory;
        private List<UIElement>? upstreamAttenuationHistory;
        private List<UIElement>? downstreamAttenuationHistory;
        private List<UIElement>? upstreamPowerHistory;
        private List<UIElement>? downstreamPowerHistory;

        public WanDslInterfaceConfigInfoControlViewModel()
        {
            WanDslInterfaceConfigGetInfoResponses = new List<WanDslInterfaceConfigGetInfoResponse>();
            UpstreamCurrRateHistory = new List<UIElement>();
            DownstreamCurrRateHistory = new List<UIElement>();
            UpstreamMaxRateHistory = new List<UIElement>();
            DownstreamMaxRateHistory = new List<UIElement>();
            UpstreamNoiseMarginHistory = new List<UIElement>();
            DownstreamNoiseMarginHistory = new List<UIElement>();
            UpstreamAttenuationHistory = new List<UIElement>();
            DownstreamAttenuationHistory = new List<UIElement>();
            UpstreamPowerHistory = new List<UIElement>();
            DownstreamPowerHistory = new List<UIElement>();
        }

        public List<WanDslInterfaceConfigGetInfoResponse> WanDslInterfaceConfigGetInfoResponses { get; set; }

        public WanDslInterfaceConfigGetInfoResponse? WanDslInterfaceConfigGetInfoResponse
        {
            get => wanDslInterfaceConfigGetInfoResponse;
            set
            {
                WanDslInterfaceConfigGetInfoResponses.Add(value!);

                if (WanDslInterfaceConfigGetInfoResponses.Count > 1)
                {
                    UpstreamCurrRateHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => q.UpstreamCurrRate).ToList());
                    DownstreamCurrRateHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => q.DownstreamCurrRate).ToList());
                    UpstreamMaxRateHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => q.UpstreamMaxRate).ToList());
                    DownstreamMaxRateHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => q.DownstreamMaxRate).ToList());
                    UpstreamNoiseMarginHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => q.UpstreamNoiseMargin).ToList());
                    DownstreamNoiseMarginHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => q.DownstreamNoiseMargin).ToList());
                    UpstreamAttenuationHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => q.UpstreamAttenuation).ToList());
                    DownstreamAttenuationHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => q.DownstreamAttenuation).ToList());
                    UpstreamPowerHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => (uint)q.UpstreamPower).ToList());
                    DownstreamPowerHistory = UpdateHistory(WanDslInterfaceConfigGetInfoResponses.Select(q => (uint)q.DownstreamPower).ToList());
                }

                _ = SetProperty(ref wanDslInterfaceConfigGetInfoResponse, value);
            }
        }

        public List<UIElement>? UpstreamCurrRateHistory
        {
            get => upstreamCurrRateHistory; set { _ = SetProperty(ref upstreamCurrRateHistory, value); }
        }

        public List<UIElement>? DownstreamCurrRateHistory
        {
            get => downstreamCurrRateHistory; set { _ = SetProperty(ref downstreamCurrRateHistory, value); }
        }

        public List<UIElement>? UpstreamMaxRateHistory
        {
            get => upstreamMaxRateHistory; set { _ = SetProperty(ref upstreamMaxRateHistory, value); }
        }

        public List<UIElement>? DownstreamMaxRateHistory
        {
            get => downstreamMaxRateHistory; set { _ = SetProperty(ref downstreamMaxRateHistory, value); }
        }

        public List<UIElement>? UpstreamNoiseMarginHistory
        {
            get => upstreamMaxRateHistory; set { _ = SetProperty(ref upstreamMaxRateHistory, value); }
        }

        public List<UIElement>? DownstreamNoiseMarginHistory
        {
            get => downstreamNoiseMarginHistory; set { _ = SetProperty(ref downstreamNoiseMarginHistory, value); }
        }

        public List<UIElement>? UpstreamAttenuationHistory
        {
            get => upstreamAttenuationHistory; set { _ = SetProperty(ref upstreamAttenuationHistory, value); }
        }

        public List<UIElement>? DownstreamAttenuationHistory
        {
            get => downstreamAttenuationHistory; set { _ = SetProperty(ref downstreamAttenuationHistory, value); }
        }

        public List<UIElement>? UpstreamPowerHistory
        {
            get => upstreamPowerHistory; set { _ = SetProperty(ref upstreamPowerHistory, value); }
        }

        public List<UIElement>? DownstreamPowerHistory
        {
            get => downstreamPowerHistory; set { _ = SetProperty(ref downstreamPowerHistory, value); }
        }

        private static List<UIElement> UpdateHistory(List<uint> values)
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

            if (range == 0)
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
                    Fill = Brushes.Green,
                    Stroke = Brushes.Green
                };

                uiElements.Add(line);
            }

            var labelMax = new Label { Content = labelMaxValue, Foreground = Brushes.LightGreen, LayoutTransform = new ScaleTransform { ScaleY = -1d } };
            var labelMin = new Label { Content = labelMinValue, Foreground = Brushes.Orange, LayoutTransform = new ScaleTransform { ScaleY = -1d } };

            Canvas.SetLeft(labelMax, uiElements.OfType<Line>().Last().X2);
            Canvas.SetTop(labelMax, 0.5);
            Canvas.SetLeft(labelMin, uiElements.OfType<Line>().Last().X2);
            Canvas.SetTop(labelMin, 0.5 - 15d);
            uiElements.AddRange(new[] { labelMax, labelMin });

            return uiElements;
        }
    }
}
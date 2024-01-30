namespace RS.Fritz.Manager.UI;

using System.Globalization;
using System.Windows;
using System.Windows.Data;

internal sealed class NullVisibilityValueConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is null ? parameter is string defaultInvisibility ? Enum.Parse<Visibility>(defaultInvisibility) : Visibility.Collapsed : Visibility.Visible;

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
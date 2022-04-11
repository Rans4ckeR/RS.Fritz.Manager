namespace RS.Fritz.Manager.UI;

using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

internal sealed class DictionaryMultiValueConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values.Length == 2 && values[0] is IDictionary dictionary)
            return dictionary[values[1]]!;

        return Binding.DoNothing;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
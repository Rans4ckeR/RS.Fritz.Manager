namespace RS.Fritz.Manager.UI;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

internal sealed class NoScrollDataGrid : DataGrid
{
    public NoScrollDataGrid()
    {
        PreviewMouseWheel += OnPreviewMouseWheel;
    }

    private static void OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
    {
        if (e.Handled)
            return;

        e.Handled = true;

        var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
        {
            RoutedEvent = MouseWheelEvent,
            Source = sender
        };
        var parent = ((Control)sender).Parent as UIElement;

        parent?.RaiseEvent(eventArg);
    }
}
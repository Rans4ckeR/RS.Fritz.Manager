namespace RS.Fritz.Manager.UI;

using System.Diagnostics;
using System.Windows.Documents;
using System.Windows.Navigation;

internal sealed class ExternalBrowserHyperlink : Hyperlink
{
    public ExternalBrowserHyperlink()
    {
        RequestNavigate += OnRequestNavigate;
    }

    private static void OnRequestNavigate(object sender, RequestNavigateEventArgs e)
    {
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
        using var _ = Process.Start(new ProcessStartInfo
        {
            FileName = e.Uri.IsAbsoluteUri ? e.Uri.AbsoluteUri : e.Uri.OriginalString,
            UseShellExecute = true
        });
#pragma warning restore SA1312 // Variable names should begin with lower-case letter

        e.Handled = true;
    }
}
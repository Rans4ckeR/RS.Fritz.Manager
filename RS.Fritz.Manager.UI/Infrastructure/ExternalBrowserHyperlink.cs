﻿namespace RS.Fritz.Manager.UI;

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
        using var _ = Process.Start(new ProcessStartInfo
        {
            FileName = e.Uri.IsAbsoluteUri ? e.Uri.AbsoluteUri : e.Uri.OriginalString,
            UseShellExecute = true
        });

        e.Handled = true;
    }
}
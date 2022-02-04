namespace RS.Fritz.Manager.UI
{
    using System.Diagnostics;
    using System.Windows.Documents;
    using System.Windows.Navigation;
    using System.Windows.Data;

    internal sealed class ExternalBrowserHyperlink : Hyperlink
    {
        public ExternalBrowserHyperlink()
        {
            RequestNavigate += OnRequestNavigate;
        }

        private static void OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = e.Uri.OriginalString,
                UseShellExecute = true
            });

            e.Handled = true;
        }
    }
}
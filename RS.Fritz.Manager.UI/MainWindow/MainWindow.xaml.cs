namespace RS.Fritz.Manager.UI
{
    using System.Windows.Controls.Ribbon;

    internal sealed partial class MainWindow : RibbonWindow
    {
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();

            DataContext = mainWindowViewModel;
        }
    }
}
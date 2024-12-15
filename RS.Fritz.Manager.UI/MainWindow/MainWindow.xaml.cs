using System.Windows;
using System.Windows.Controls;

namespace RS.Fritz.Manager.UI;

internal sealed partial class MainWindow
{
    public MainWindow(MainWindowViewModel mainWindowViewModel)
    {
        InitializeComponent();

        DataContext = mainWindowViewModel;
    }

    private void PasswordBoxPasswordChanged(object sender, RoutedEventArgs e) => ((MainWindowViewModel)DataContext).DeviceLoginInfo.Password = ((PasswordBox)sender).SecurePassword;
}
namespace RS.Fritz.Manager.UI;

using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal sealed partial class App
{
    private readonly IHost host;

    public App()
    {
        Mouse.OverrideCursor = Cursors.AppStarting;

        TaskScheduler.UnobservedTaskException += HandleTaskSchedulerUnobservedTaskException;
        DispatcherUnhandledException += AppDispatcherUnhandledException;

        host = Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                IServiceCollection unused = services
                    .AddSingleton<DeviceLoginInfo>()
                    .AddSingleton<ILogger, UserInterfaceLogService>()
                    .AddSingleton<MainWindow>()
                    .AddFritzApi()
                    .AddViewModels();
            }).Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await host.StartAsync();

        SetUiCulture();

        MainWindow mainWindow = host.Services.GetRequiredService<MainWindow>();

        PreventWpfFlashbang(mainWindow);
        mainWindow.Show();
        base.OnStartup(e);

        Mouse.OverrideCursor = null;
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        Mouse.OverrideCursor = Cursors.Wait;

        using (host)
        {
            await host.StopAsync();
        }

        base.OnExit(e);

        Mouse.OverrideCursor = null;
    }

    private static void PreventWpfFlashbang(Window window)
    {
        window.Loaded += (s, _) => ((Window)s).WindowState = WindowState.Normal;
        window.WindowState = WindowState.Minimized;
    }

    private static void SetUiCulture()
    {
        FrameworkElement.LanguageProperty.OverrideMetadata(
            typeof(FrameworkElement),
            new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
    }

    private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        ILogger logger = host.Services.GetRequiredService<ILogger>();

        e.Handled = true;

        logger.ExceptionThrown(e.Exception);
    }

    private void HandleTaskSchedulerUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        ILogger logger = host.Services.GetRequiredService<ILogger>();

        logger.ExceptionThrown(e.Exception);
    }
}
namespace RS.Fritz.Manager.UI;

using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RS.Fritz.Manager.API;

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
                services.AddSingleton<MainWindow>()
                    .AddSingleton<MainWindowViewModel>()
                    .AddSingleton<DeviceInfoViewModel>()
                    .AddSingleton<DeviceInfoSetProvisioningCodeViewModel>()
                    .AddSingleton<LanConfigSecurityViewModel>()
                    .AddSingleton<LanConfigSecuritySetConfigPasswordViewModel>()
                    .AddSingleton<WanDslInterfaceConfigViewModel>()
                    .AddSingleton<WanDslInterfaceConfigInfoViewModel>()
                    .AddSingleton<WanDslInterfaceConfigDslInfoViewModel>()
                    .AddSingleton<WanDslLinkConfigViewModel>()
                    .AddSingleton<WanCommonInterfaceConfigViewModel>()
                    .AddSingleton<WanCommonInterfaceConfigSetWanAccessTypeViewModel>()
                    .AddSingleton<WanCommonInterfaceConfigGetOnlineMonitorViewModel>()
                    .AddSingleton<HostsViewModel>()
                    .AddSingleton<HostsGetGenericHostEntryViewModel>()
                    .AddSingleton<Layer3ForwardingViewModel>()
                    .AddSingleton<WanPppConnectionViewModel>()
                    .AddSingleton<WanIpConnectionViewModel>()
                    .AddSingleton<WanEthernetLinkConfigViewModel>()
                    .AddSingleton<AvmSpeedtestViewModel>()
                    .AddSingleton<DeviceLoginInfo>()
                    .AddSingleton<ILogger, UserInterfaceLogService>()
                    .AddFritzApi();
            }).Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await host.StartAsync();

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
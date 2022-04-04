namespace RS.Fritz.Manager.UI;

using System.Windows;
using System.Windows.Input;
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
                services.AddSingleton<DeviceLoginInfo>()
                    .AddSingleton<ILogger, UserInterfaceLogService>()
                    .AddSingleton<MainWindow>()
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
                    .AddSingleton<Layer3ForwardingGetGenericForwardingEntryViewModel>()
                    .AddSingleton<WanPppConnectionViewModel>()
                    .AddSingleton<WanIpConnectionViewModel>()
                    .AddSingleton<WanEthernetLinkConfigViewModel>()
                    .AddSingleton<AvmSpeedtestViewModel>()
                    .AddSingleton<CaptureControlCaptureViewModel>()
                    .AddSingleton<WanIpConnectionGetGenericPortMappingEntryViewModel>()
                    .AddSingleton<WanPppConnectionGetGenericPortMappingEntryViewModel>()
                    .AddSingleton<LanEthernetInterfaceConfigViewModel>()
                    .AddSingleton<LanHostConfigManagementViewModel>()
                    .AddSingleton<WlanConfigurationViewModel>()
                    .AddSingleton<ManagementServerViewModel>()
                    .AddSingleton<ManagementServerSetManagementServerUrlViewModel>()
                    .AddSingleton<ManagementServerSetManagementServerUsernameViewModel>()
                    .AddSingleton<ManagementServerSetManagementServerPasswordViewModel>()
                    .AddSingleton<ManagementServerSetPeriodicInformViewModel>()
                    .AddSingleton<ManagementServerSetConnectionRequestAuthenticationViewModel>()
                    .AddSingleton<ManagementServerSetUpgradeManagementViewModel>()
                    .AddSingleton<ManagementServerSetTr069EnableViewModel>()
                    .AddSingleton<ManagementServerSetTr069FirmwareDownloadEnabledViewModel>()
                    .AddSingleton<TimeViewModel>()
                    .AddSingleton<TimeSetNtpServersViewModel>()
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
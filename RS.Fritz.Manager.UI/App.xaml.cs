namespace RS.Fritz.Manager.UI
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

    internal sealed partial class App : Application
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
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<MainWindowViewModel>();
                    services.AddSingleton<DeviceInfoViewModel>();
                    services.AddSingleton<DeviceInfoSetProvisioningCodeViewModel>();
                    services.AddSingleton<LanConfigSecurityViewModel>();
                    services.AddSingleton<LanConfigSecuritySetConfigPasswordViewModel>();
                    services.AddSingleton<WanDslInterfaceConfigViewModel>();
                    services.AddSingleton<Layer3ForwardingViewModel>();
                    services.AddSingleton<WanPppConnectionViewModel>();
                    services.AddSingleton<DeviceLoginInfo>();
                    services.AddSingleton<ILogger, UserInterfaceLogService>();
                    services.AddSingleton<IServiceOperationHandler, ServiceOperationHandler>();
                    services.AddSingleton<IDeviceSearchService, DeviceSearchService>();
                    services.AddSingleton<IFritzServiceOperationHandler, FritzServiceOperationHandler>();
                    services.AddSingleton<IClientFactory<IFritzLanConfigSecurityService>, ClientFactory<IFritzLanConfigSecurityService>>();
                    services.AddSingleton<IClientFactory<IFritzDeviceInfoService>, ClientFactory<IFritzDeviceInfoService>>();
                    services.AddSingleton<IClientFactory<IFritzWanDslInterfaceConfigService>, ClientFactory<IFritzWanDslInterfaceConfigService>>();
                    services.AddSingleton<IClientFactory<IFritzLayer3ForwardingService>, ClientFactory<IFritzLayer3ForwardingService>>();
                    services.AddSingleton<IClientFactory<IFritzWanPppConnectionService>, ClientFactory<IFritzWanPppConnectionService>>();
                    ConfigureHttpClients(services);
                }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();

            var mainWindow = host.Services.GetRequiredService<MainWindow>();

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

        private static void ConfigureHttpClients(IServiceCollection services)
        {
            services.AddHttpClient(Constants.HttpClientName)
                .ConfigureHttpClient((_, httpClient) =>
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(60);
                    httpClient.DefaultRequestVersion = Version.Parse("2.0");
                })
                .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.All
                });
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var logger = host.Services.GetRequiredService<ILogger>();

            e.Handled = true;

            logger.ExceptionThrown(e.Exception);
        }

        private void HandleTaskSchedulerUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            var logger = host.Services.GetRequiredService<ILogger>();

            logger.ExceptionThrown(e.Exception);
        }
    }
}
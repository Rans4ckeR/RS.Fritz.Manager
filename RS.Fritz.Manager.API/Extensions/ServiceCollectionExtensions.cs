namespace RS.Fritz.Manager.API;

using System.Net;
using System.Net.Security;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddFritzApi(this IServiceCollection services)
    {
        _ = services.AddSingleton<IDeviceSearchService, DeviceSearchService>()
            .AddSingleton<IDeviceHostsService, DeviceHostsService>()
            .AddSingleton<IDeviceMeshService, DeviceMeshService>()
            .AddSingleton<IWlanDeviceService, WlanDeviceService>()
            .AddSingleton<ICaptureControlService, CaptureControlService>()
            .AddSingleton<IFritzServiceOperationHandler, FritzServiceOperationHandler>()
            .AddSingleton<IUsersService, UsersService>()
            .AddSingleton<IWebUiService, WebUiService>()
            .AddSingleton<IClientFactory<IFritzLanConfigSecurityService>, ClientFactory<IFritzLanConfigSecurityService>>()
            .AddSingleton<IClientFactory<IFritzDeviceInfoService>, ClientFactory<IFritzDeviceInfoService>>()
            .AddSingleton<IClientFactory<IFritzWanDslInterfaceConfigService>, ClientFactory<IFritzWanDslInterfaceConfigService>>()
            .AddSingleton<IClientFactory<IFritzHostsService>, ClientFactory<IFritzHostsService>>()
            .AddSingleton<IClientFactory<IFritzWanCommonInterfaceConfigService>, ClientFactory<IFritzWanCommonInterfaceConfigService>>()
            .AddSingleton<IClientFactory<IFritzLayer3ForwardingService>, ClientFactory<IFritzLayer3ForwardingService>>()
            .AddSingleton<IClientFactory<IFritzWanPppConnectionService>, ClientFactory<IFritzWanPppConnectionService>>()
            .AddSingleton<IClientFactory<IFritzWanIpConnectionService>, ClientFactory<IFritzWanIpConnectionService>>()
            .AddSingleton<IClientFactory<IFritzWanEthernetLinkConfigService>, ClientFactory<IFritzWanEthernetLinkConfigService>>()
            .AddSingleton<IClientFactory<IFritzWanDslLinkConfigService>, ClientFactory<IFritzWanDslLinkConfigService>>()
            .AddSingleton<IClientFactory<IFritzAvmSpeedtestService>, ClientFactory<IFritzAvmSpeedtestService>>()
            .AddSingleton<IClientFactory<IFritzLanEthernetInterfaceConfigService>, ClientFactory<IFritzLanEthernetInterfaceConfigService>>()
            .AddSingleton<IClientFactory<IFritzLanHostConfigManagementService>, ClientFactory<IFritzLanHostConfigManagementService>>()
            .AddSingleton<IClientFactory<IFritzWlanConfiguration1Service>, ClientFactory<IFritzWlanConfiguration1Service>>()
            .AddSingleton<IClientFactory<IFritzWlanConfiguration2Service>, ClientFactory<IFritzWlanConfiguration2Service>>()
            .AddSingleton<IClientFactory<IFritzWlanConfiguration3Service>, ClientFactory<IFritzWlanConfiguration3Service>>()
            .AddSingleton<IClientFactory<IFritzWlanConfiguration4Service>, ClientFactory<IFritzWlanConfiguration4Service>>();
        ConfigureHttpClients(services);
    }

    private static void ConfigureHttpClients(IServiceCollection services)
    {
        _ = services.AddHttpClient(Constants.HttpClientName)
            .ConfigureHttpClient((_, httpClient) =>
            {
                httpClient.Timeout = TimeSpan.FromSeconds(60);
                httpClient.DefaultRequestVersion = Version.Parse("2.0");
            })
            .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.All
            });
        _ = services.AddHttpClient(Constants.NonValidatingHttpsClientName)
            .ConfigureHttpClient((_, httpClient) =>
            {
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                httpClient.DefaultRequestVersion = Version.Parse("2.0");
            })
            .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (_, _, _, sslPolicyErrors) => (sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) == 0,
                AutomaticDecompression = DecompressionMethods.All
            });
    }
}
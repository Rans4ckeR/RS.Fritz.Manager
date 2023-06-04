namespace RS.Fritz.Manager.API;

using System.Net;
using System.Net.Security;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFritzApi(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddSingleton<IDeviceSearchService, DeviceSearchService>()
            .AddSingleton<IDeviceHostsService, DeviceHostsService>()
            .AddSingleton<IDeviceMeshService, DeviceMeshService>()
            .AddSingleton<IWlanDeviceService, WlanDeviceService>()
            .AddSingleton<ICaptureControlService, CaptureControlService>()
            .AddSingleton<IFritzServiceOperationHandler, FritzServiceOperationHandler>()
            .AddSingleton<IUsersService, UsersService>()
            .AddSingleton<IWebUiService, WebUiService>()
            .AddSingleton<INetworkService, NetworkService>()
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
            .AddSingleton<IClientFactory<IFritzWlanConfiguration4Service>, ClientFactory<IFritzWlanConfiguration4Service>>()
            .AddSingleton<IClientFactory<IFritzManagementServerService>, ClientFactory<IFritzManagementServerService>>()
            .AddSingleton<IClientFactory<IFritzTimeService>, ClientFactory<IFritzTimeService>>()
            .AddSingleton<IClientFactory<IFritzUserInterfaceService>, ClientFactory<IFritzUserInterfaceService>>()
            .AddSingleton<IClientFactory<IFritzDeviceConfigService>, ClientFactory<IFritzDeviceConfigService>>()
            .ConfigureHttpClients();
    }

    private static IServiceCollection ConfigureHttpClients(this IServiceCollection serviceCollection)
    {
        _ = serviceCollection.AddHttpClient(Constants.DefaultHttpClientName)
            .ConfigureHttpClient((_, httpClient) =>
            {
                httpClient.Timeout = TimeSpan.FromSeconds(10);
                httpClient.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrHigher;
            })
            .ConfigurePrimaryHttpMessageHandler(_ => new SocketsHttpHandler
            {
                SslOptions = new()
                {
                    RemoteCertificateValidationCallback = (_, _, _, sslPolicyErrors) => (sslPolicyErrors & SslPolicyErrors.RemoteCertificateNotAvailable) is 0,
                    CertificateChainPolicy = new()
                    {
                        DisableCertificateDownloads = true
                    }
                },
                AutomaticDecompression = DecompressionMethods.All
            });

        return serviceCollection;
    }
}
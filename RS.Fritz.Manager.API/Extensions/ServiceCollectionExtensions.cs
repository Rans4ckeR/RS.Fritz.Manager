namespace RS.Fritz.Manager.API;

using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void AddFritzApi(this IServiceCollection services)
    {
        _ = services.AddSingleton<IDeviceSearchService, DeviceSearchService>()
            .AddSingleton<IDeviceHostsService, DeviceHostsService>()
            .AddSingleton<ICaptureControlService, CaptureControlService>()
            .AddSingleton<IFritzServiceOperationHandler, FritzServiceOperationHandler>()
            .AddSingleton<IClientFactory<IFritzLanConfigSecurityService>, ClientFactory<IFritzLanConfigSecurityService>>()
            .AddSingleton<IClientFactory<IFritzDeviceInfoService>, ClientFactory<IFritzDeviceInfoService>>()
            .AddSingleton<IClientFactory<IFritzWanDslInterfaceConfigService>, ClientFactory<IFritzWanDslInterfaceConfigService>>()
            .AddSingleton<IClientFactory<IFritzHostsService>, ClientFactory<IFritzHostsService>>()
            .AddSingleton<IClientFactory<IFritzWanCommonInterfaceConfigService>, ClientFactory<IFritzWanCommonInterfaceConfigService>>()
            .AddSingleton<IClientFactory<IFritzLayer3ForwardingService>, ClientFactory<IFritzLayer3ForwardingService>>()
            .AddSingleton<IClientFactory<IFritzWanPppConnectionService>, ClientFactory<IFritzWanPppConnectionService>>()
            .AddSingleton<IClientFactory<IFritzWanIpConnectionService>, ClientFactory<IFritzWanIpConnectionService>>()
            .AddSingleton<IClientFactory<IFritzWanEthernetLinkConfigService>, ClientFactory<IFritzWanEthernetLinkConfigService>>()
            .AddSingleton<IClientFactory<ICaptureControlService>, ClientFactory<ICaptureControlService>>();
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
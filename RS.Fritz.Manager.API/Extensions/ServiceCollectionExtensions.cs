namespace RS.Fritz.Manager.API
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Security;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static void AddFritzApi(this IServiceCollection services)
        {
            services.AddSingleton<IDeviceSearchService, DeviceSearchService>();
            services.AddSingleton<IDeviceHostsService, DeviceHostsService>();
            services.AddSingleton<IFritzServiceOperationHandler, FritzServiceOperationHandler>();
            services.AddSingleton<IClientFactory<IFritzLanConfigSecurityService>, ClientFactory<IFritzLanConfigSecurityService>>();
            services.AddSingleton<IClientFactory<IFritzDeviceInfoService>, ClientFactory<IFritzDeviceInfoService>>();
            services.AddSingleton<IClientFactory<IFritzWanDslInterfaceConfigService>, ClientFactory<IFritzWanDslInterfaceConfigService>>();
            services.AddSingleton<IClientFactory<IFritzHostsService>, ClientFactory<IFritzHostsService>>();
            services.AddSingleton<IClientFactory<IFritzWanCommonInterfaceConfigService>, ClientFactory<IFritzWanCommonInterfaceConfigService>>();
            services.AddSingleton<IClientFactory<IFritzLayer3ForwardingService>, ClientFactory<IFritzLayer3ForwardingService>>();
            services.AddSingleton<IClientFactory<IFritzWanPppConnectionService>, ClientFactory<IFritzWanPppConnectionService>>();
            services.AddSingleton<IClientFactory<IFritzWanIpConnectionService>, ClientFactory<IFritzWanIpConnectionService>>();
            ConfigureHttpClients(services);
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
            services.AddHttpClient(Constants.NonValidatingHttpsClientName)
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
}
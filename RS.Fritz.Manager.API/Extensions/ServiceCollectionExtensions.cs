namespace RS.Fritz.Manager.API;

using System.Net;
using System.Net.Security;
using System.ServiceModel.Channels;
using Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddFritzApi(this IServiceCollection serviceCollection) =>
        serviceCollection.AddSingleton<IDeviceSearchService, DeviceSearchService>()
            .AddSingleton<IDeviceHostsService, DeviceHostsService>()
            .AddSingleton<IDeviceMeshService, DeviceMeshService>()
            .AddSingleton<IWlanDeviceService, WlanDeviceService>()
            .AddSingleton<ICaptureControlService, CaptureControlService>()
            .AddSingleton<IFritzServiceOperationHandler, FritzServiceOperationHandler>()
            .AddSingleton<IUsersService, UsersService>()
            .AddSingleton<IWebUiService, WebUiService>()
            .AddSingleton<INetworkService, NetworkService>()
            .AddWcfClient<IFritzLanConfigSecurityService, FritzLanConfigSecurityService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzDeviceInfoService, FritzDeviceInfoService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWanDslInterfaceConfigService, FritzWanDslInterfaceConfigService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzHostsService, FritzHostsService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWanCommonInterfaceConfigService, FritzWanCommonInterfaceConfigService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzLayer3ForwardingService, FritzLayer3ForwardingService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWanPppConnectionService, FritzWanPppConnectionService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWanIpConnectionService, FritzWanIpConnectionService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWanEthernetLinkConfigService, FritzWanEthernetLinkConfigService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWanDslLinkConfigService, FritzWanDslLinkConfigService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzAvmSpeedtestService, FritzAvmSpeedtestService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzLanEthernetInterfaceConfigService, FritzLanEthernetInterfaceConfigService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzLanHostConfigManagementService, FritzLanHostConfigManagementService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWlanConfiguration1Service, FritzWlanConfiguration1Service>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWlanConfiguration2Service, FritzWlanConfiguration2Service>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWlanConfiguration3Service, FritzWlanConfiguration3Service>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzWlanConfiguration4Service, FritzWlanConfiguration4Service>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzManagementServerService, FritzManagementServerService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzTimeService, FritzTimeService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzUserInterfaceService, FritzUserInterfaceService>((binding, endpointAddress) => new(binding, endpointAddress))
            .AddWcfClient<IFritzDeviceConfigService, FritzDeviceConfigService>((binding, endpointAddress) => new(binding, endpointAddress))
            .ConfigureHttpClients();

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
                AutomaticDecompression = DecompressionMethods.All,
                PooledConnectionLifetime = TimeSpan.FromMinutes(15)
            })
            .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

        return serviceCollection;
    }

    private static IServiceCollection AddWcfClient<TInterface, TClient>(this IServiceCollection serviceCollection, Func<Binding, EndpointAddress, TClient> clientFactoryFunc)
        where TInterface : class, IFritzService
        where TClient : ClientBase<TInterface>, TInterface
    {
        ClientBase<TInterface>.CacheSetting = CacheSetting.AlwaysOn;

        _ = serviceCollection
            .AddSingleton(clientFactoryFunc)
            .AddSingleton<IClientFactory<TClient>, ClientFactory<TInterface, TClient>>()
            .AddHttpClient(typeof(TInterface).ToString())
            .ConfigurePrimaryHttpMessageHandler(_ => new SocketsHttpHandler
            {
                AutomaticDecompression = DecompressionMethods.All,
                PooledConnectionLifetime = TimeSpan.FromMinutes(15),
                PreAuthenticate = true
            })
            .SetHandlerLifetime(Timeout.InfiniteTimeSpan);

        return serviceCollection;
    }
}
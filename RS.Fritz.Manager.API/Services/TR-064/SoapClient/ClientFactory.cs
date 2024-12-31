using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class ClientFactory<T>(INetworkService networkService, ILoggerFactory loggerFactory) : IClientFactory<T>
    where T : class
{
    private readonly INetworkService networkService = networkService;
    private readonly ILoggerFactory loggerFactory = loggerFactory;

    public T Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, ILoggerFactory, T> createClient, Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential)
        => createClient(GetEndpointConfiguration(secure), GetEndpointAddress(location, secure, controlUrl, port), networkCredential, loggerFactory);

    private static FritzServiceEndpointConfiguration GetEndpointConfiguration(bool secure)
        => secure ? FritzServiceEndpointConfiguration.BasicHttpsBindingIFritzService : FritzServiceEndpointConfiguration.BasicHttpBindingIFritzService;

    private EndpointAddress GetEndpointAddress(Uri location, bool secure, string controlUrl, ushort? port = null)
    {
        Uri endPointUri = networkService.FormatUri(secure ? Uri.UriSchemeHttps : Uri.UriSchemeHttp, location, port ?? (ushort)location.Port, controlUrl);

        return new(endPointUri);
    }
}
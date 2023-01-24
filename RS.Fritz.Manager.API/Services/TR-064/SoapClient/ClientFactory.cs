namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class ClientFactory<T> : IClientFactory<T>
    where T : class
{
    private readonly INetworkService networkService;

    public ClientFactory(INetworkService networkService)
    {
        this.networkService = networkService;
    }

    public T Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createClient, Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential)
    {
        return createClient(GetEndpointConfiguration(secure), GetEndpointAddress(location, secure, controlUrl, port), networkCredential);
    }

    private static FritzServiceEndpointConfiguration GetEndpointConfiguration(bool secure)
    {
        return secure ? FritzServiceEndpointConfiguration.BasicHttpsBindingIFritzService : FritzServiceEndpointConfiguration.BasicHttpBindingIFritzService;
    }

    private EndpointAddress GetEndpointAddress(Uri location, bool secure, string controlUrl, ushort? port = null)
    {
        Uri endPointUri = networkService.FormatUri(secure ? Uri.UriSchemeHttps : Uri.UriSchemeHttp, location, port ?? (ushort)location.Port, controlUrl);

        return new(endPointUri);
    }
}
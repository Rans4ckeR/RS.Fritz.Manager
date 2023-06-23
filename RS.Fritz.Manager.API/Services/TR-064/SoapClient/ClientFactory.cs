namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class ClientFactory<T>(INetworkService networkService) : IClientFactory<T>
    where T : class
{
    public T Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createClient, Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential)
        => createClient(GetEndpointConfiguration(secure), GetEndpointAddress(location, secure, controlUrl, port), networkCredential);

    private static FritzServiceEndpointConfiguration GetEndpointConfiguration(bool secure)
        => secure ? FritzServiceEndpointConfiguration.BasicHttpsBindingIFritzService : FritzServiceEndpointConfiguration.BasicHttpBindingIFritzService;

    private EndpointAddress GetEndpointAddress(Uri location, bool secure, string controlUrl, ushort? port = null)
    {
        Uri endPointUri = networkService.FormatUri(secure ? Uri.UriSchemeHttps : Uri.UriSchemeHttp, location, port ?? (ushort)location.Port, controlUrl);

        return new(endPointUri);
    }
}
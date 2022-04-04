namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class ClientFactory<T> : IClientFactory<T>
    where T : class
{
    public T Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createClient, Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential)
    {
        return createClient(GetEndpointConfiguration(secure), GetEndpointAddress(location, secure, controlUrl, port), networkCredential);
    }

    private static EndpointAddress GetEndpointAddress(Uri location, bool secure, string controlUrl, int? port = null)
    {
        return new EndpointAddress(new Uri(FormattableString.Invariant($"{(secure ? "https" : "http")}://{(port is null ? location.Authority : $"{location.Host}:{port.Value}")}{controlUrl}")));
    }

    private static FritzServiceEndpointConfiguration GetEndpointConfiguration(bool secure)
    {
        return secure ? FritzServiceEndpointConfiguration.BasicHttpsBindingIFritzService : FritzServiceEndpointConfiguration.BasicHttpBindingIFritzService;
    }
}
using System.Net;

namespace RS.Fritz.Manager.API;

internal interface IClientFactory<T>
{
    T Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createClient, Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential);
}
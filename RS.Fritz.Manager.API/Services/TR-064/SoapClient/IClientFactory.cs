using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal interface IClientFactory<T>
{
    T Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, ILoggerFactory, T> createClient, Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential);
}
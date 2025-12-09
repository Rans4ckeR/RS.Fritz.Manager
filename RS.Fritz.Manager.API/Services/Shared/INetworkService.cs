using System.Net;

namespace RS.Fritz.Manager.API;

internal interface INetworkService
{
    Uri FormatUri(string scheme, Uri uri, ushort port, string path);

    Uri FormatUri(IPEndPoint ipEndPoint, string? scheme = null, string? path = null);

    bool IsPrivateIpAddress(IPAddress ipAddress);

    IEnumerable<IPAddress> GetUnicastAddresses();

    IEnumerable<IPAddress> GetMulticastAddresses();
}
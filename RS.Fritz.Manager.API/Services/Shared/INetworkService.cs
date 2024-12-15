using System.Net;

namespace RS.Fritz.Manager.API;

internal interface INetworkService
{
    public Uri FormatUri(string scheme, Uri uri, ushort port, string path);

    public Uri FormatUri(IPEndPoint ipEndPoint, string? scheme = null, string? path = null);

    public bool IsPrivateIpAddress(IPAddress ipAddress);

    public IEnumerable<IPAddress> GetUnicastAddresses();

    public IEnumerable<IPAddress> GetMulticastAddresses();
}
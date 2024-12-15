using System.Collections.Frozen;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace RS.Fritz.Manager.API;

internal sealed class NetworkService : INetworkService
{
    private static readonly FrozenSet<AddressFamily> SupportedAddressFamilies = new[]
    {
        AddressFamily.InterNetwork,
        AddressFamily.InterNetworkV6
    }.ToFrozenSet();

    public Uri FormatUri(string scheme, Uri uri, ushort port, string path)
    {
        string[] pathAndQuery = path.Split('?');
        var uriBuilder = new UriBuilder(uri)
        {
            Scheme = scheme,
            Host = uri.IdnHost,
            Port = port,
            Path = pathAndQuery.First(),
            Query = pathAndQuery.Skip(1).SingleOrDefault()
        };

        return uriBuilder.Uri;
    }

    public Uri FormatUri(IPEndPoint ipEndPoint, string? scheme = null, string? path = null)
    {
        var uriBuilder = new UriBuilder(scheme ?? Uri.UriSchemeHttps, ipEndPoint.Address.ToString(), ipEndPoint.Port, path);

        return uriBuilder.Uri;
    }

    public bool IsPrivateIpAddress(IPAddress ipAddress)
        => ipAddress.AddressFamily switch
        {
            AddressFamily.InterNetworkV6 => ipAddress.IsIPv6SiteLocal || ipAddress.IsIPv6UniqueLocal || ipAddress.IsIPv6LinkLocal,
            AddressFamily.InterNetwork => IPNetwork.Parse("10.0.0.0/8").Contains(ipAddress)
                || IPNetwork.Parse("172.16.0.0/12").Contains(ipAddress)
                || IPNetwork.Parse("192.168.0.0/16").Contains(ipAddress)
                || IPNetwork.Parse("169.254.0.0/16").Contains(ipAddress)
                || IPNetwork.Parse("127.0.0.0/8").Contains(ipAddress)
                || IPNetwork.Parse("0.0.0.0/8").Contains(ipAddress),
            _ => throw new ArgumentOutOfRangeException(nameof(ipAddress), ipAddress, null)
        };

    public IEnumerable<IPAddress> GetUnicastAddresses()
        => GetIpInterfaces()
            .SelectMany(q => q.UnicastAddresses.Select(r => r.Address))
            .Where(q => SupportedAddressFamilies.Contains(q.AddressFamily));

    public IEnumerable<IPAddress> GetMulticastAddresses()
        => GetIpInterfaces()
            .SelectMany(q => q.MulticastAddresses.Select(r => r.Address))
            .Where(q => SupportedAddressFamilies.Contains(q.AddressFamily));

    private static IEnumerable<IPInterfaceProperties> GetIpInterfaces()
        => NetworkInterface.GetAllNetworkInterfaces()
            .Where(q => q.OperationalStatus is OperationalStatus.Up && q.NetworkInterfaceType is not NetworkInterfaceType.Loopback)
            .Select(q => q.GetIPProperties())
            .Where(q => q.GatewayAddresses.Count is not 0);
}
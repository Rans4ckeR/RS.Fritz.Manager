namespace RS.Fritz.Manager.API;

using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

internal sealed class NetworkService : INetworkService
{
    private static readonly IReadOnlyList<AddressFamily> SupportedAddressFamilies = new List<AddressFamily>
    {
        AddressFamily.InterNetwork,
        AddressFamily.InterNetworkV6
    }.AsReadOnly();

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
#pragma warning disable IDE0072 // Add missing cases
        => ipAddress.AddressFamily switch
        {
            AddressFamily.InterNetworkV6 => ipAddress.IsIPv6SiteLocal || ipAddress.IsIPv6UniqueLocal || ipAddress.IsIPv6LinkLocal,
            AddressFamily.InterNetwork => IsInRange("10.0.0.0", "10.255.255.255", ipAddress)
                || IsInRange("172.16.0.0", "172.31.255.255", ipAddress)
                || IsInRange("192.168.0.0", "192.168.255.255", ipAddress)
                || IsInRange("169.254.0.0", "169.254.255.255", ipAddress)
                || IsInRange("127.0.0.0", "127.255.255.255", ipAddress)
                || IsInRange("0.0.0.0", "0.255.255.255", ipAddress),
            _ => throw new ArgumentOutOfRangeException(nameof(ipAddress), ipAddress, null)
        };
#pragma warning restore IDE0072 // Add missing cases

    public IEnumerable<IPAddress> GetUnicastAddresses()
        => GetIpInterfaces()
            .SelectMany(q => q.UnicastAddresses.Select(r => r.Address))
            .Where(q => SupportedAddressFamilies.Contains(q.AddressFamily));

    public IEnumerable<IPAddress> GetMulticastAddresses()
        => GetIpInterfaces()
            .SelectMany(q => q.MulticastAddresses.Select(r => r.Address))
            .Where(q => SupportedAddressFamilies.Contains(q.AddressFamily));

    private static bool IsInRange(string startIpAddress, string endIpAddress, IPAddress address)
    {
        uint ipStart = BitConverter.ToUInt32(IPAddress.Parse(startIpAddress).GetAddressBytes().Reverse().ToArray(), 0);
        uint ipEnd = BitConverter.ToUInt32(IPAddress.Parse(endIpAddress).GetAddressBytes().Reverse().ToArray(), 0);
        uint ip = BitConverter.ToUInt32(address.GetAddressBytes().Reverse().ToArray(), 0);

        return ip >= ipStart && ip <= ipEnd;
    }

    private static IEnumerable<IPInterfaceProperties> GetIpInterfaces()
        => NetworkInterface.GetAllNetworkInterfaces()
            .Where(q => q.OperationalStatus is OperationalStatus.Up && q.NetworkInterfaceType is not NetworkInterfaceType.Loopback)
            .Select(q => q.GetIPProperties())
            .Where(q => q.GatewayAddresses.Count is not 0);
}
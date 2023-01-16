namespace RS.Fritz.Manager.API;

using System.Buffers;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

internal sealed class DeviceSearchService : IDeviceSearchService
{
    private const string InternetGatewayDeviceDeviceType = "urn:dslforum-org:device:InternetGatewayDevice:1";
    private const int UPnPMultiCastPort = 1900;
    private const int ReceiveTimeoutInSeconds = 2;
    private const int DefaultSendCount = 1;

    private readonly IHttpClientFactory httpClientFactory;
    private readonly IFritzServiceOperationHandler fritzServiceOperationHandler;
    private readonly IUsersService usersService;
    private readonly AddressFamily[] supportedAddressFamilies = { AddressFamily.InterNetwork, AddressFamily.InterNetworkV6 };

    public DeviceSearchService(IHttpClientFactory httpClientFactory, IFritzServiceOperationHandler fritzServiceOperationHandler, IUsersService usersService)
    {
        this.httpClientFactory = httpClientFactory;
        this.fritzServiceOperationHandler = fritzServiceOperationHandler;
        this.usersService = usersService;
    }

    private static IReadOnlyDictionary<AddressType, IPAddress> SsdpMultiCastAddresses => new Dictionary<AddressType, IPAddress>
    {
        [AddressType.IpV4SiteLocal] = IPAddress.Parse("239.255.255.250"),
        [AddressType.IpV6LinkLocal] = IPAddress.Parse("[FF02::C]"),
        [AddressType.IpV6SiteLocal] = IPAddress.Parse("[FF05::C]")
    }.AsReadOnly();

    public async ValueTask<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string? deviceType = null, int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default)
    {
        deviceType ??= InternetGatewayDeviceDeviceType;
        timeout ??= ReceiveTimeoutInSeconds * 1000;
        sendCount ??= DefaultSendCount;

        IEnumerable<string> rawDeviceResponses = await GetRawDeviceResponses(deviceType, sendCount.Value, timeout.Value, cancellationToken);
        IEnumerable<Dictionary<string, string>> formattedDeviceResponses = GetFormattedDeviceResponses(rawDeviceResponses);
        IEnumerable<IGrouping<string, InternetGatewayDeviceResponse>> groupedInternetGatewayDeviceResponses = GetGroupedInternetGatewayDeviceResponses(formattedDeviceResponses);

        return await TaskExtensions.WhenAllSafe(groupedInternetGatewayDeviceResponses.Select(q => GetInternetGatewayDeviceAsync(q, cancellationToken)));
    }

    private static IEnumerable<IGrouping<string, InternetGatewayDeviceResponse>> GetGroupedInternetGatewayDeviceResponses(IEnumerable<Dictionary<string, string>> formattedDeviceResponses)
    {
        return formattedDeviceResponses
            .Select(q => new InternetGatewayDeviceResponse(new Uri(q["LOCATION"]), q["SERVER"], q["CACHE-CONTROL"], q["EXT"], q["ST"], q["USN"]))
            .GroupBy(q => q.Usn);
    }

    private static Uri GetPreferredLocation(IReadOnlyCollection<Uri> locations)
    {
        return locations.SingleOrDefault(q => q.HostNameType is UriHostNameType.IPv6) ?? locations.Single(q => q.HostNameType is UriHostNameType.IPv4);
    }

    private static IEnumerable<Dictionary<string, string>> GetFormattedDeviceResponses(IEnumerable<string> responses)
    {
        return responses.Select(q => q.Split(Environment.NewLine)).Select(q => q.Where(r => r.Contains(':', StringComparison.OrdinalIgnoreCase)).ToDictionary(
            s => s[..s.IndexOf(':', StringComparison.OrdinalIgnoreCase)],
            s =>
            {
                string value = s[s.IndexOf(':', StringComparison.OrdinalIgnoreCase)..];

                if (value.EndsWith(":", StringComparison.OrdinalIgnoreCase))
                    return value.Replace(":", null, StringComparison.OrdinalIgnoreCase);

                return value.Replace(": ", null, StringComparison.OrdinalIgnoreCase);
            },
            StringComparer.OrdinalIgnoreCase));
    }

    private static async Task<IEnumerable<string>> SearchDevicesAsync(IPAddress localAddress, string deviceType, int sendCount, int receiveTimeout, CancellationToken cancellationToken)
    {
        var responses = new List<string>();
        AddressType addressType = GetAddressType(localAddress);

        if (addressType is AddressType.Unknown)
            return responses;

        using var socket = new Socket(localAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

        socket.ExclusiveAddressUse = true;

        socket.Bind(new IPEndPoint(localAddress, 0));

        var multiCastIpEndPoint = new IPEndPoint(SsdpMultiCastAddresses[addressType], UPnPMultiCastPort);
        string request = FormattableString.Invariant($"M-SEARCH * HTTP/1.1\r\nHOST: {multiCastIpEndPoint}\r\nST: {deviceType}\r\nMAN: \"ssdp:discover\"\r\nMX: {ReceiveTimeoutInSeconds}\r\n\r\n");
        const int charSize = sizeof(char);
        int bufferSize = request.Length * charSize;
        using IMemoryOwner<byte> memoryOwner = MemoryPool<byte>.Shared.Rent(bufferSize);
        Memory<byte> buffer = memoryOwner.Memory[..bufferSize];
        int bytes = Encoding.UTF8.GetBytes(request.AsSpan(), buffer.Span);

        buffer = buffer[..bytes];

        for (int i = 0; i < sendCount; i++)
        {
            _ = await socket.SendToAsync(buffer, SocketFlags.None, multiCastIpEndPoint, cancellationToken);
        }

        await ReceiveAsync(socket, responses, receiveTimeout, cancellationToken);

        return responses;
    }

    private static AddressType GetAddressType(IPAddress localAddress)
    {
        if (localAddress.AddressFamily == AddressFamily.InterNetwork)
            return AddressType.IpV4SiteLocal;

        if (localAddress.IsIPv6LinkLocal)
            return AddressType.IpV6LinkLocal;

        if (localAddress.IsIPv6SiteLocal)
            return AddressType.IpV6SiteLocal;

        return AddressType.Unknown;
    }

    private static async ValueTask ReceiveAsync(Socket socket, ICollection<string> responses, int receiveTimeout, CancellationToken cancellationToken)
    {
        using IMemoryOwner<byte> memoryOwner = MemoryPool<byte>.Shared.Rent(4096);
        using var timeoutCancellationTokenSource = new CancellationTokenSource(receiveTimeout);
        using var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutCancellationTokenSource.Token, cancellationToken);

        while (!linkedCancellationTokenSource.IsCancellationRequested)
        {
            Memory<byte> buffer = memoryOwner.Memory[..4096];

            try
            {
                int bytesReceived = await socket.ReceiveAsync(buffer, SocketFlags.None, linkedCancellationTokenSource.Token);

                responses.Add(Encoding.UTF8.GetString(buffer.Span[..bytesReceived]));
            }
            catch (OperationCanceledException)
            {
            }
        }
    }

    private async ValueTask<IEnumerable<string>> GetRawDeviceResponses(string deviceType, int sendCount, int timeout, CancellationToken cancellationToken)
    {
        IEnumerable<IPAddress> localAddresses = GetLocalAddresses();
        IEnumerable<string>[] localAddressesDeviceResponses = await TaskExtensions.WhenAllSafe(localAddresses.Select(q => SearchDevicesAsync(q, deviceType, sendCount, timeout, cancellationToken)));

        return localAddressesDeviceResponses.Where(q => q.Any()).SelectMany(q => q).Distinct();
    }

    private IEnumerable<IPAddress> GetLocalAddresses()
    {
        return NetworkInterface.GetAllNetworkInterfaces()
            .Where(q => q.OperationalStatus is OperationalStatus.Up)
            .Select(q => q.GetIPProperties())
            .Where(q => q.GatewayAddresses.Any())
            .SelectMany(q => q.UnicastAddresses)
            .Select(q => q.Address)
            .Where(q => supportedAddressFamilies.Contains(q.AddressFamily));
    }

    private async ValueTask<UPnPDescription> GetUPnPDescription(Uri uri, CancellationToken cancellationToken)
    {
        await using Stream uPnPDescription = await httpClientFactory.CreateClient(Constants.HttpClientName).GetStreamAsync(uri, cancellationToken);
        using var xmlTextReader = new XmlTextReader(uPnPDescription);

        return (UPnPDescription)new DataContractSerializer(typeof(UPnPDescription)).ReadObject(xmlTextReader)!;
    }

    private async Task<InternetGatewayDevice> GetInternetGatewayDeviceAsync(IGrouping<string, InternetGatewayDeviceResponse> internetGatewayDeviceResponses, CancellationToken cancellationToken)
    {
        Uri preferredLocation = GetPreferredLocation(internetGatewayDeviceResponses.Select(r => r.Location).ToArray());

        return new InternetGatewayDevice(
            fritzServiceOperationHandler,
            usersService,
            internetGatewayDeviceResponses.Select(r => r.Location).Distinct(),
            internetGatewayDeviceResponses.Select(r => r.Server).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.CacheControl).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.Ext).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.SearchTarget).Distinct().Single(),
            internetGatewayDeviceResponses.Key,
            await GetUPnPDescription(preferredLocation, cancellationToken),
            preferredLocation);
    }
}
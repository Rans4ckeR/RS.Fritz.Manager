namespace RS.Fritz.Manager.API;

using System.Buffers;
using System.Net;
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
    private readonly INetworkService networkService;

    public DeviceSearchService(IHttpClientFactory httpClientFactory, IFritzServiceOperationHandler fritzServiceOperationHandler, IUsersService usersService, INetworkService networkService)
    {
        this.httpClientFactory = httpClientFactory;
        this.fritzServiceOperationHandler = fritzServiceOperationHandler;
        this.usersService = usersService;
        this.networkService = networkService;
    }

    public async ValueTask<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string? deviceType = null, int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default)
    {
        deviceType ??= InternetGatewayDeviceDeviceType;
        timeout ??= ReceiveTimeoutInSeconds * 1000;
        sendCount ??= DefaultSendCount;

        IEnumerable<(IPAddress LocalIpAddress, IEnumerable<string> Responses)> rawDeviceResponses = await GetRawDeviceResponses(deviceType, sendCount.Value, timeout.Value, cancellationToken).ConfigureAwait(false);
        IEnumerable<(IPAddress LocalIpAddress, IEnumerable<Dictionary<string, string>> Responses)> formattedDeviceResponses =
            rawDeviceResponses.Select(q => (q.LocalIpAddress, GetFormattedDeviceResponses(q.Responses)));
        IEnumerable<IGrouping<string, InternetGatewayDeviceResponse>> groupedInternetGatewayDeviceResponses =
            GetGroupedInternetGatewayDeviceResponses(formattedDeviceResponses);

        return await TaskExtensions.WhenAllSafe(groupedInternetGatewayDeviceResponses.Select(q => GetInternetGatewayDeviceAsync(q, cancellationToken))).ConfigureAwait(false);
    }

    private static IEnumerable<IGrouping<string, InternetGatewayDeviceResponse>> GetGroupedInternetGatewayDeviceResponses(
        IEnumerable<(IPAddress LocalIpAddress, IEnumerable<Dictionary<string, string>> Responses)> formattedDeviceResponses)
    {
        return formattedDeviceResponses
            .SelectMany(q => q.Responses.Select(r => new InternetGatewayDeviceResponse(new(r["LOCATION"]), r["SERVER"], r["CACHE-CONTROL"], r["EXT"], r["ST"], r["USN"], q.LocalIpAddress)))
            .GroupBy(q => q.Usn);
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
                int bytesReceived = await socket.ReceiveAsync(buffer, SocketFlags.None, linkedCancellationTokenSource.Token).ConfigureAwait(false);

                responses.Add(Encoding.UTF8.GetString(buffer.Span[..bytesReceived]));
            }
            catch (OperationCanceledException)
            {
            }
        }
    }

    private Uri GetPreferredLocation(IReadOnlyCollection<Uri> locations)
    {
        return locations.FirstOrDefault(q => q.HostNameType is UriHostNameType.IPv6 && !networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? locations.FirstOrDefault(q => q.HostNameType is UriHostNameType.IPv6 && networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? locations.First(q => q.HostNameType is UriHostNameType.IPv4);
    }

    private Uri ParseLocation((IPAddress LocalIpAddress, Uri Location) location)
    {
        if (location.Location.HostNameType is not UriHostNameType.IPv6 || !IPAddress.TryParse(location.Location.IdnHost, out IPAddress? ipAddress) || !networkService.IsPrivateIpAddress(ipAddress))
            return location.Location;

        return networkService.FormatUri(new(IPAddress.Parse(FormattableString.Invariant($"{location.Location.IdnHost}%{location.LocalIpAddress.ScopeId}")), location.Location.Port), location.Location.Scheme, location.Location.PathAndQuery);
    }

    private async Task<(IPAddress IpAddress, IEnumerable<string> Responses)> SearchDevicesAsync(IPAddress unicastAddress, IPAddress multicastAddress, string deviceType, int sendCount, int receiveTimeout, CancellationToken cancellationToken)
    {
        var responses = new List<string>();
        using var socket = new Socket(SocketType.Dgram, ProtocolType.Udp);

        socket.Bind(new IPEndPoint(unicastAddress, 0));

        var multiCastIpEndPoint = new IPEndPoint(multicastAddress, UPnPMultiCastPort);
        string request = FormattableString.Invariant($"M-SEARCH * HTTP/1.1\r\nHOST: {networkService.FormatUri(multiCastIpEndPoint).Authority}\r\nST: {deviceType}\r\nMAN: \"ssdp:discover\"\r\nMX: {ReceiveTimeoutInSeconds}\r\n\r\n");
        const int charSize = sizeof(char);
        int bufferSize = request.Length * charSize;
        using IMemoryOwner<byte> memoryOwner = MemoryPool<byte>.Shared.Rent(bufferSize);
        Memory<byte> buffer = memoryOwner.Memory[..bufferSize];
        int bytes = Encoding.UTF8.GetBytes(request.AsSpan(), buffer.Span);

        buffer = buffer[..bytes];

        for (int i = 0; i < sendCount; i++)
        {
            _ = await socket.SendToAsync(buffer, SocketFlags.None, multiCastIpEndPoint, cancellationToken).ConfigureAwait(false);
        }

        await ReceiveAsync(socket, responses, receiveTimeout, cancellationToken).ConfigureAwait(false);

        return new(unicastAddress, responses);
    }

    private async ValueTask<IEnumerable<(IPAddress LocalIpAddress, IEnumerable<string> Responses)>> GetRawDeviceResponses(string deviceType, int sendCount, int timeout, CancellationToken cancellationToken)
    {
        IEnumerable<IPAddress> unicastAddresses = networkService.GetUnicastAddresses();
        IEnumerable<IPAddress> multicastAddresses = networkService.GetMulticastAddresses();
        (IPAddress LocalIpAddress, IEnumerable<string> Responses)[] localAddressesDeviceResponses = await TaskExtensions.WhenAllSafe(multicastAddresses.SelectMany(q => unicastAddresses.Where(r => r.AddressFamily == q.AddressFamily).Select(r => SearchDevicesAsync(r, q, deviceType, sendCount, timeout, cancellationToken)))).ConfigureAwait(false);

        return localAddressesDeviceResponses.Where(q => q.Responses.Any(r => r.Length is not 0)).Select(q => (q.LocalIpAddress, q.Responses)).Distinct();
    }

    private async ValueTask<UPnPDescription> GetUPnPDescription(Uri uri, CancellationToken cancellationToken)
    {
        Stream uPnPDescription = await httpClientFactory.CreateClient(Constants.DefaultHttpClientName).GetStreamAsync(uri, cancellationToken).ConfigureAwait(false);

        await using (uPnPDescription.ConfigureAwait(false))
        {
            using var xmlTextReader = new XmlTextReader(uPnPDescription);

            return (UPnPDescription)new DataContractSerializer(typeof(UPnPDescription)).ReadObject(xmlTextReader)!;
        }
    }

    private async Task<InternetGatewayDevice> GetInternetGatewayDeviceAsync(IGrouping<string, InternetGatewayDeviceResponse> internetGatewayDeviceResponses, CancellationToken cancellationToken)
    {
        Uri[] locations = internetGatewayDeviceResponses.Select(q => (q.LocalIpAddress, q.Location)).Distinct().Select(ParseLocation).ToArray();
        Uri preferredLocation = GetPreferredLocation(locations);

        return new(
            fritzServiceOperationHandler,
            usersService,
            locations,
            internetGatewayDeviceResponses.Select(r => r.Server).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.CacheControl).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.Ext).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.SearchTarget).Distinct().Single(),
            internetGatewayDeviceResponses.Key,
            await GetUPnPDescription(preferredLocation, cancellationToken).ConfigureAwait(false),
            preferredLocation,
            internetGatewayDeviceResponses.Select(r => r.LocalIpAddress).Distinct().ToList().AsReadOnly());
    }
}
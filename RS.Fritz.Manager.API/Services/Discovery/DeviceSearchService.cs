using System.Buffers;
using System.Collections.Frozen;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class DeviceSearchService(
    IHttpClientFactory httpClientFactory,
    IFritzServiceOperationHandler fritzServiceOperationHandler,
    IUsersService usersService,
    INetworkService networkService,
    ILogger<DeviceSearchService> logger)
    : IDeviceSearchService
{
    private static readonly FrozenSet<string> InternetGatewayDeviceDeviceTypes = [UPnPConstants.InternetGatewayDeviceV2DeviceType, UPnPConstants.InternetGatewayDeviceV1DeviceType, UPnPConstants.InternetGatewayDeviceV1AvmDeviceType];

    private readonly INetworkService networkService = networkService;
    private readonly IHttpClientFactory httpClientFactory = httpClientFactory;
    private readonly IFritzServiceOperationHandler fritzServiceOperationHandler = fritzServiceOperationHandler;
    private readonly IUsersService usersService = usersService;
    private readonly ILogger logger = logger;

    // <inheritdoc/>
    public async ValueTask<GroupedInternetGatewayDevice?> GetInternetGatewayDeviceAsync(IPAddress ipAddress, ushort port = UPnPConstants.AvmPort, CancellationToken cancellationToken = default)
    {
        IPEndPoint ipEndPoint = new(ipAddress, port);
        List<(Uri Uri, string DeviceType, UPnPDescription UPnPDescription)> descriptions =
        [
            .. await Task.WhenAll(InternetGatewayDeviceDeviceTypes.Select(async q =>
            {
                string path = q switch
                {
                    UPnPConstants.InternetGatewayDeviceV1AvmDeviceType => "tr64desc.xml",
                    UPnPConstants.InternetGatewayDeviceV2DeviceType => "igd2desc.xml",
                    UPnPConstants.InternetGatewayDeviceV1DeviceType => "igddesc.xml",
                    _ => throw new ArgumentOutOfRangeException(nameof(q), q, null)
                };
                Uri uri = networkService.FormatUri(ipEndPoint, Uri.UriSchemeHttp, path);

                return (uri, q, await GetUPnPDescription(uri, q, cancellationToken).ConfigureAwait(false));
            })).Evaluate().ConfigureAwait(false)
        ];

        if (descriptions.Count is 0)
            return null;

        List<InternetGatewayDevice> internetGatewayDevices =
        [
            .. descriptions.Select(q => new InternetGatewayDevice(
                fritzServiceOperationHandler,
                usersService,
                null,
                null,
                null,
                [q.Uri],
                q.UPnPDescription.Device!.Value.ModelName,
                q.DeviceType,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                q.UPnPDescription,
                q.Uri,
                [],
                ushort.TryParse(q.DeviceType[..1], out ushort version) ? version : null))
        ];

        return new(
            internetGatewayDevices.SelectMany(static q => q.Locations ?? []),
            null,
            internetGatewayDevices,
            internetGatewayDevices.MaxBy(static q => q.Version)?.PreferredLocation,
            [ipAddress]);
    }

    // <inheritdoc/>
    public async ValueTask<GroupedInternetGatewayDevice[]> GetInternetGatewayDevicesAsync(int sendCount = 1, int timeoutInSeconds = 1, IPEndPoint? ipEndPoint = null, CancellationToken cancellationToken = default)
    {
        List<ServerDeviceResponse> serverDeviceResponses = await GetRawDeviceResponsesAsync(InternetGatewayDeviceDeviceTypes, sendCount, timeoutInSeconds, ipEndPoint, cancellationToken).ConfigureAwait(false);

        return await Task.WhenAll(serverDeviceResponses.Select(q => ParseInternetGatewayDeviceAsync(q, cancellationToken))).Evaluate().ConfigureAwait(false);
    }

    // <inheritdoc/>
    public async ValueTask<List<ServerDeviceResponse>> GetRawDeviceResponsesAsync(IEnumerable<string> deviceTypes, int sendCount = 1, int timeoutInSeconds = 1, IPEndPoint? ipEndPoint = null, CancellationToken cancellationToken = default)
    {
        IEnumerable<Task<IEnumerable<(IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)>>> tasks = deviceTypes.Select(q => GetRawDeviceResponses(q, sendCount, timeoutInSeconds, ipEndPoint, cancellationToken));
        IEnumerable<(IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)>[] responses = await Task.WhenAll(tasks).Evaluate().ConfigureAwait(false);

        return ParseServerDeviceResponses(responses.SelectMany(static q => q));
    }

    private static List<ServerDeviceResponse> ParseServerDeviceResponses(IEnumerable<(IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)> rawDeviceResponses)
    {
        IEnumerable<(IPAddress LocalIpAddress, IEnumerable<(IPAddress IPAddress, FrozenDictionary<string, string> Values)> Responses)> formattedDeviceResponses =
            rawDeviceResponses.Select(static q => (q.LocalIpAddress, GetFormattedDeviceResponses(q.Responses)));
        IEnumerable<DeviceSearchResponse> deviceSearchResponses = formattedDeviceResponses.SelectMany(static q => q.Responses.Select(r => new DeviceSearchResponse(
               r.Values.GetValueOrDefault("CACHE-CONTROL"),
               r.Values.GetValueOrDefault("DATE"),
               r.Values.GetValueOrDefault("EXT"),
               r.Values.TryGetValue("LOCATION", out string? location) ? new(location) : null,
               r.Values.GetValueOrDefault("SERVER"),
               r.Values.GetValueOrDefault("ST"),
               r.Values.GetValueOrDefault("USN"),
               r.Values.GetValueOrDefault("OPT"),
               r.Values.GetValueOrDefault("01-NLS"),
               r.Values.TryGetValue("BOOTID.UPNP.ORG", out string? bootId) ? int.Parse(bootId, CultureInfo.InvariantCulture) : null,
               r.Values.TryGetValue("CONFIGID.UPNP.ORG", out string? configId) ? int.Parse(configId, CultureInfo.InvariantCulture) : null,
               r.Values.TryGetValue("SEARCHPORT.UPNP.ORG", out string? unicastSearchPort) ? ushort.Parse(unicastSearchPort, CultureInfo.InvariantCulture) : null,
               r.Values.TryGetValue("SECURELOCATION.UPNP.ORG", out string? secureLocation) ? new(secureLocation) : null,
               r.IPAddress,
               q.LocalIpAddress))).Distinct();
        IEnumerable<IGrouping<string?, DeviceSearchResponse>> usnGrouping = deviceSearchResponses.GroupBy(static q => q.Usn);
        FrozenSet<UsnDeviceResponse> usnDeviceResponses = [.. usnGrouping.Select(static q => new UsnDeviceResponse { Usn = q.Key, Server = q.Select(static r => r.Server).Distinct().Single(), DeviceSearchResponses = [.. q] })];
        List<ServerDeviceResponse> serverDeviceResponses = [];

        foreach (UsnDeviceResponse usnDeviceResponse in usnDeviceResponses)
        {
            if (serverDeviceResponses.Any(q => q.IpAddresses.OrderBy(static r => r.GetHashCode()).SequenceEqual(usnDeviceResponse.DeviceSearchResponses.Select(static r => r.IpAddress).Distinct().OrderBy(static r => r.GetHashCode()))))
                continue;

            FrozenSet<UsnDeviceResponse> serverDeviceUsnDeviceResponses = [.. usnDeviceResponses.Where(q => q.DeviceSearchResponses.Any(r => usnDeviceResponse.DeviceSearchResponses.Select(static s => s.IpAddress).Contains(r.IpAddress)))];

            serverDeviceResponses.Add(new(usnDeviceResponse.Server, [.. serverDeviceUsnDeviceResponses.SelectMany(static q => q.DeviceSearchResponses.Select(static r => r.IpAddress)).Distinct()], serverDeviceUsnDeviceResponses));
        }

        return serverDeviceResponses;
    }

    private static IEnumerable<(IPAddress IPAddress, FrozenDictionary<string, string> Values)> GetFormattedDeviceResponses(IEnumerable<(IPAddress IPAddress, string Response)> responses)
        => responses.Select(static q => (q.IPAddress, q.Response.Split("\r\n").Where(static r => r.Contains(':', StringComparison.OrdinalIgnoreCase)).ToFrozenDictionary(
            static s => s[..s.IndexOf(':', StringComparison.OrdinalIgnoreCase)],
            static s =>
            {
                string value = s[s.IndexOf(':', StringComparison.OrdinalIgnoreCase)..];

                return value.Replace(value.EndsWith(':') ? ":" : ": ", null, StringComparison.OrdinalIgnoreCase);
            },
            StringComparer.OrdinalIgnoreCase)));

    private static SystemVersion GetBaseSystemVersion(AvmSystemVersion systemVersion)
        => new(systemVersion.Hw, systemVersion.Major, systemVersion.Minor, systemVersion.Patch, systemVersion.BuildNumber, systemVersion.Display);

    private static SpecVersion GetBaseSpecVersion(AvmSpecVersion specVersion)
        => new(specVersion.Major, specVersion.Minor);

    private static ServiceListItem GetBaseServiceListItem(AvmServiceListItem serviceListItem)
        => new(serviceListItem.ServiceType, serviceListItem.ServiceId, serviceListItem.ControlUrl, serviceListItem.EventSubUrl, serviceListItem.ScpdUrl);

    private static ServiceListItem GetBaseServiceListItem(SoapServiceListItem serviceListItem)
        => new(serviceListItem.ServiceType, serviceListItem.ServiceId, serviceListItem.ControlUrl, serviceListItem.EventSubUrl, serviceListItem.ScpdUrl);

    private static IconListItem GetBaseIconListItem(AvmIconListItem iconListItem)
        => new(iconListItem.Mimetype, iconListItem.Width, iconListItem.Height, iconListItem.Depth, iconListItem.Url);

    private static IconListItem GetBaseIconListItem(SoapIconListItem iconListItem)
        => new(iconListItem.Mimetype, iconListItem.Width, iconListItem.Height, iconListItem.Depth, iconListItem.Url);

    private static Device GetBaseDevice(SoapDevice device)
        => new(
            device.DeviceType,
            device.FriendlyName,
            device.Manufacturer,
            device.ManufacturerUrl,
            device.ModelDescription,
            device.ModelName,
            device.ModelNumber,
            device.ModelUrl,
            device.UniqueDeviceName,
            device.UniversalProductCode,
            device.SerialNumber,
            null,
            device.IconList?.Select(GetBaseIconListItem).ToList(),
            device.ServiceList?.Select(GetBaseServiceListItem).ToList(),
            device.DeviceList?.Select(GetBaseDevice).ToList(),
            device.PresentationUrl);

    private static Device GetBaseDevice(AvmDevice device)
        => new(
            device.DeviceType,
            device.FriendlyName,
            device.Manufacturer,
            device.ManufacturerUrl,
            device.ModelDescription,
            device.ModelName,
            device.ModelNumber,
            device.ModelUrl,
            device.UniqueDeviceName,
            null,
            device.SerialNumber,
            device.OriginUniqueDeviceName,
            device.IconList?.Select(GetBaseIconListItem).ToList(),
            device.ServiceList?.Select(GetBaseServiceListItem).ToList(),
            device.DeviceList?.Select(GetBaseDevice).ToList(),
            device.PresentationUrl);

    private static Device GetBaseDevice(AvmDeviceListDevice device)
        => new(
            device.DeviceType,
            device.FriendlyName,
            device.Manufacturer,
            device.ManufacturerUrl,
            device.ModelDescription,
            device.ModelName,
            device.ModelNumber,
            device.ModelUrl,
            device.UniqueDeviceName,
            device.UniversalProductCode,
            null,
            null,
            null,
            device.ServiceList?.Select(GetBaseServiceListItem).ToList(),
            device.DeviceList?.Select(GetBaseDevice).ToList(),
            null);

    private async ValueTask<FrozenSet<(IPAddress IPAddress, string Response)>> ReceiveAsync(Socket socket, int timeoutInSeconds, CancellationToken cancellationToken)
    {
        List<(IPAddress IPAddress, string Response)> responses = [];
        var receivedAddress = new SocketAddress(socket.AddressFamily);
        using IMemoryOwner<byte> memoryOwner = MemoryPool<byte>.Shared.Rent(4096);
        using var timeoutCancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(timeoutInSeconds));
        using var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutCancellationTokenSource.Token, cancellationToken);

        while (!linkedCancellationTokenSource.IsCancellationRequested)
        {
            Memory<byte> buffer = memoryOwner.Memory[..4096];

            try
            {
                int bytesReceived = await socket.ReceiveFromAsync(buffer, SocketFlags.None, receivedAddress, linkedCancellationTokenSource.Token).ConfigureAwait(false);
                var remoteIpEndPoint = (IPEndPoint)new IPEndPoint(0L, 0).Create(receivedAddress);
                string response = Encoding.UTF8.GetString(buffer.Span[..bytesReceived]);

                logger.DiscoverReply((socket.LocalEndPoint as IPEndPoint)!, remoteIpEndPoint, response);

                responses.Add((remoteIpEndPoint.Address, response));
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
            }
        }

        return [.. responses];
    }

    private Uri? GetPreferredLocation(IReadOnlyCollection<Uri?> secureLocations, IReadOnlyCollection<Uri?> locations)
        => secureLocations.FirstOrDefault(q => Socket.OSSupportsIPv6 && q?.HostNameType is UriHostNameType.IPv6 && !networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? secureLocations.FirstOrDefault(q => Socket.OSSupportsIPv6 && q?.HostNameType is UriHostNameType.IPv6 && networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? secureLocations.FirstOrDefault(static q => Socket.OSSupportsIPv4 && q?.HostNameType is UriHostNameType.IPv4)
            ?? locations.FirstOrDefault(q => Socket.OSSupportsIPv6 && q?.HostNameType is UriHostNameType.IPv6 && !networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? locations.FirstOrDefault(q => Socket.OSSupportsIPv6 && q?.HostNameType is UriHostNameType.IPv6 && networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? locations.FirstOrDefault(static q => Socket.OSSupportsIPv4 && q?.HostNameType is UriHostNameType.IPv4);

    private Uri? ParseLocation((IPAddress LocalIpAddress, Uri? Location) location) =>
        location.Location?.HostNameType is not UriHostNameType.IPv6 || !IPAddress.TryParse(location.Location.IdnHost, out IPAddress? ipAddress) || !networkService.IsPrivateIpAddress(ipAddress)
            ? location.Location
            : networkService.FormatUri(new(IPAddress.Parse(FormattableString.Invariant($"{location.Location.IdnHost}%{location.LocalIpAddress.ScopeId}")), location.Location.Port), location.Location.Scheme, location.Location.PathAndQuery);

    private async Task<(IPAddress IpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)> SearchDevicesAsync(IPAddress localAddress, IPEndPoint remoteIpEndPoint, string deviceType, int sendCount, int timeoutInSeconds, bool multiCast, CancellationToken cancellationToken)
    {
        FrozenSet<(IPAddress IPAddress, string Response)> responses = [];
        var localIpEndPoint = new IPEndPoint(localAddress, 0);
        using var socket = new Socket(localAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

        socket.Bind(localIpEndPoint);

        string request = FormattableString.Invariant($"M-SEARCH * HTTP/1.1\r\nHOST: {networkService.FormatUri(remoteIpEndPoint).Authority}\r\nMAN: \"ssdp:discover\"\r\n{(multiCast ? $"MX: {timeoutInSeconds}\r\n" : null)}ST: {deviceType}\r\nCPFN.UPNP.ORG: RS.Fritz.Manager\r\n\r\n");
        const int charSize = sizeof(char);
        int bufferSize = request.Length * charSize;
        using IMemoryOwner<byte> memoryOwner = MemoryPool<byte>.Shared.Rent(bufferSize);
        Memory<byte> buffer = memoryOwner.Memory[..bufferSize];
        int bytes = Encoding.UTF8.GetBytes(request.AsSpan(), buffer.Span);

        buffer = buffer[..bytes];

        SocketAddress remoteSocketAddress = remoteIpEndPoint.Serialize();

        try
        {
            for (int i = 0; i < sendCount; i++)
            {
                logger.DiscoverRequest(localIpEndPoint, remoteIpEndPoint, request);

                _ = await socket.SendToAsync(buffer, SocketFlags.None, remoteSocketAddress, cancellationToken).ConfigureAwait(false);
            }

            responses = await ReceiveAsync(socket, timeoutInSeconds, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
        }

        return new(localAddress, responses);
    }

    private async Task<IEnumerable<(IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)>> GetRawDeviceResponses(string deviceType, int sendCount, int timeoutInSeconds, IPEndPoint? ipEndPoint, CancellationToken cancellationToken = default)
    {
        IEnumerable<IPAddress> sourceIpAddresses = networkService.GetUnicastAddresses();
        IEnumerable<IPEndPoint> destinationIpEndpoints = ipEndPoint is not null ? [ipEndPoint] : networkService.GetMulticastAddresses().Select(static q => new IPEndPoint(q, UPnPConstants.MultiCastPort));
        (IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)[] localAddressesDeviceResponses = await Task.WhenAll(destinationIpEndpoints.SelectMany(q => sourceIpAddresses.Where(r => r.AddressFamily == q.AddressFamily).Select(r => SearchDevicesAsync(r, q, deviceType, sendCount, timeoutInSeconds, ipEndPoint is null, cancellationToken)))).Evaluate().ConfigureAwait(false);

        return localAddressesDeviceResponses.Where(static q => q.Responses.Any(static r => r.Response.Length is not 0)).Select(static q => (q.LocalIpAddress, q.Responses)).Distinct();
    }

    private async ValueTask<UPnPDescription> GetUPnPDescription(Uri uri, string usn, CancellationToken cancellationToken)
    {
        Stream description = await httpClientFactory.CreateClient(Constants.DefaultHttpClientName).GetStreamAsync(uri, cancellationToken).ConfigureAwait(false);

        await using (description.ConfigureAwait(false))
        {
            using var xmlTextReader = new XmlTextReader(description);

            if (usn.Contains(UPnPConstants.InternetGatewayDeviceV1AvmDeviceType, StringComparison.OrdinalIgnoreCase))
            {
                var uPnPDescription = (AvmUPnPDescription)new DataContractSerializer(typeof(AvmUPnPDescription)).ReadObject(xmlTextReader)!;

                return new(GetBaseSpecVersion(uPnPDescription.SpecVersion), null, GetBaseDevice(uPnPDescription.Device), GetBaseSystemVersion(uPnPDescription.SystemVersion));
            }
            else
            {
                var uPnPDescription = (SoapUPnPDescription)new DataContractSerializer(typeof(SoapUPnPDescription)).ReadObject(xmlTextReader)!;

                return new(null, uPnPDescription.UrlBase, GetBaseDevice(uPnPDescription.Device), null);
            }
        }
    }

    private async Task<GroupedInternetGatewayDevice> ParseInternetGatewayDeviceAsync(ServerDeviceResponse serverDeviceResponse, CancellationToken cancellationToken)
    {
        List<InternetGatewayDevice> internetGatewayDevices = [];

        foreach (UsnDeviceResponse usnDeviceResponse in serverDeviceResponse.UsnDeviceResponses)
        {
            FrozenSet<Uri?> locations = [.. usnDeviceResponse.DeviceSearchResponses.Where(static r => r.Location is not null).Select(static r => (r.IpAddress, r.Location)).Distinct().Select(ParseLocation)];
            FrozenSet<Uri?> secureLocations = [.. usnDeviceResponse.DeviceSearchResponses.Where(static r => r.SecureLocation is not null).Select(static r => (r.IpAddress, r.SecureLocation)).Distinct().Select(ParseLocation)];
            Uri? preferredLocation = GetPreferredLocation(secureLocations, locations);
            UPnPDescription? description = null;

            if (preferredLocation is not null)
            {
                try
                {
                    description = await GetUPnPDescription(preferredLocation, usnDeviceResponse.Usn!, cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                {
                    if (preferredLocation.HostNameType is UriHostNameType.IPv6 && Socket.OSSupportsIPv4 && locations.Any(static q => q?.HostNameType is UriHostNameType.IPv4))
                    {
                        try
                        {
                            preferredLocation = locations.First(static q => q?.HostNameType is UriHostNameType.IPv4);
                            description = await GetUPnPDescription(preferredLocation!, serverDeviceResponse.UsnDeviceResponses.Select(static q => q.Usn).Distinct().Single()!, cancellationToken).ConfigureAwait(false);
                        }
                        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
                        {
                        }
                    }
                }
            }

            internetGatewayDevices.Add(new(
                fritzServiceOperationHandler,
                usersService,
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.CacheControl).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.Date).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.Ext).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.Location),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.Server).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.SearchTarget).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.Usn).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.Opt).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.Nls).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.BootId).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.ConfigId).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.UnicastSearchPort).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(static r => r.SecureLocation),
                description,
                preferredLocation,
                [.. usnDeviceResponse.DeviceSearchResponses.Select(static r => r.LocalIpAddress)],
                ushort.TryParse(usnDeviceResponse.DeviceSearchResponses.Select(static r => r.Usn).Distinct().SingleOrDefault()?[..1], out ushort version) ? version : null));
        }

        return new(
            internetGatewayDevices.SelectMany(static q => q.Locations ?? []),
            serverDeviceResponse.Server,
            internetGatewayDevices,
            internetGatewayDevices.MaxBy(static q => q.Version)?.PreferredLocation,
            serverDeviceResponse.IpAddresses);
    }
}
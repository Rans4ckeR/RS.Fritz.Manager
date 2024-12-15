using System.Buffers;
using System.Collections.Frozen;
using System.Globalization;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;

namespace RS.Fritz.Manager.API;

internal sealed class DeviceSearchService(IHttpClientFactory httpClientFactory, IFritzServiceOperationHandler fritzServiceOperationHandler, IUsersService usersService, INetworkService networkService)
    : IDeviceSearchService
{
    public async ValueTask<IEnumerable<GroupedInternetGatewayDevice>> GetInternetGatewayDevicesAsync(int sendCount = 1, int timeout = 2000, CancellationToken cancellationToken = default)
    {
        Task<IEnumerable<(IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)>>[] tasks =
        [
            GetRawDeviceResponses(UPnPConstants.InternetGatewayDeviceV2DeviceType, sendCount, timeout, cancellationToken),
            GetRawDeviceResponses(UPnPConstants.InternetGatewayDeviceV1DeviceType, sendCount, timeout, cancellationToken),
            GetRawDeviceResponses(UPnPConstants.InternetGatewayDeviceV1AvmDeviceType, sendCount, timeout, cancellationToken)
        ];
        IEnumerable<(IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)>[] responses = await TaskExtensions.WhenAllSafe(tasks).ConfigureAwait(false);
        List<ServerDeviceResponse> serverDeviceResponses = GetServerDeviceResponses(responses.SelectMany(q => q));

        return await TaskExtensions.WhenAllSafe(serverDeviceResponses.Select(q => ParseInternetGatewayDeviceAsync(q, cancellationToken))).ConfigureAwait(false);
    }

    public async ValueTask<List<ServerDeviceResponse>> GetDevicesAsync(string deviceType = UPnPConstants.RootDeviceDeviceType, int sendCount = 1, int timeout = 2000, CancellationToken cancellationToken = default)
    {
        IEnumerable<(IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)> rawDeviceResponses = await GetRawDeviceResponses(deviceType, sendCount, timeout, cancellationToken).ConfigureAwait(false);

        return GetServerDeviceResponses(rawDeviceResponses);
    }

    private static List<ServerDeviceResponse> GetServerDeviceResponses(IEnumerable<(IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)> rawDeviceResponses)
    {
        IEnumerable<(IPAddress LocalIpAddress, IEnumerable<(IPAddress IPAddress, FrozenDictionary<string, string> Values)> Responses)> formattedDeviceResponses =
            rawDeviceResponses.Select(q => (q.LocalIpAddress, GetFormattedDeviceResponses(q.Responses)));
        IEnumerable<DeviceSearchResponse> deviceSearchResponses = formattedDeviceResponses.SelectMany(q => q.Responses.Select(r => new DeviceSearchResponse(
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
               r.Values.TryGetValue("SEARCHPORT.UPNP.ORG", out string? searchPort) ? ushort.Parse(searchPort, CultureInfo.InvariantCulture) : null,
               r.Values.TryGetValue("SECURELOCATION.UPNP.ORG", out string? secureLocation) ? new(secureLocation) : null,
               r.IPAddress,
               q.LocalIpAddress))).Distinct();
        IEnumerable<IGrouping<string?, DeviceSearchResponse>> usnGrouping = deviceSearchResponses.GroupBy(q => q.Usn);
        var usnDeviceResponses = usnGrouping.Select(q => new UsnDeviceResponse { Usn = q.Key, Server = q.Select(r => r.Server).Distinct().Single(), DeviceSearchResponses = q.ToFrozenSet() }).ToFrozenSet();
        var serverDeviceResponses = new List<ServerDeviceResponse>();

        foreach (UsnDeviceResponse usnDeviceResponse in usnDeviceResponses)
        {
            if (serverDeviceResponses.Any(q => q.IpAddresses.OrderBy(r => r.GetHashCode()).SequenceEqual(usnDeviceResponse.DeviceSearchResponses.Select(r => r.IpAddress).Distinct().OrderBy(r => r.GetHashCode()))))
                continue;

            var serverDeviceUsnDeviceResponses = usnDeviceResponses.Where(q => q.DeviceSearchResponses.Any(r => usnDeviceResponse.DeviceSearchResponses.Select(s => s.IpAddress).Contains(r.IpAddress))).ToFrozenSet();

            serverDeviceResponses.Add(new(usnDeviceResponse.Server, serverDeviceUsnDeviceResponses.SelectMany(q => q.DeviceSearchResponses.Select(r => r.IpAddress)).Distinct().ToFrozenSet(), serverDeviceUsnDeviceResponses));
        }

        return serverDeviceResponses;
    }

    private static IEnumerable<(IPAddress IPAddress, FrozenDictionary<string, string> Values)> GetFormattedDeviceResponses(IEnumerable<(IPAddress IPAddress, string Response)> responses)
        => responses.Select(q => (q.IPAddress, q.Response.Split("\r\n").Where(r => r.Contains(':', StringComparison.OrdinalIgnoreCase)).ToFrozenDictionary(
            s => s[..s.IndexOf(':', StringComparison.OrdinalIgnoreCase)],
            s =>
            {
                string value = s[s.IndexOf(':', StringComparison.OrdinalIgnoreCase)..];

                return value.Replace(value.EndsWith(':') ? ":" : ": ", null, StringComparison.OrdinalIgnoreCase);
            },
            StringComparer.OrdinalIgnoreCase)));

    private static async ValueTask<FrozenSet<(IPAddress IPAddress, string Response)>> ReceiveAsync(Socket socket, int receiveTimeout, CancellationToken cancellationToken)
    {
        var responses = new List<(IPAddress IPAddress, string Response)>();
        var receivedAddress = new SocketAddress(socket.AddressFamily);
        using IMemoryOwner<byte> memoryOwner = MemoryPool<byte>.Shared.Rent(4096);
        using var timeoutCancellationTokenSource = new CancellationTokenSource(receiveTimeout);
        using var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutCancellationTokenSource.Token, cancellationToken);

        while (!linkedCancellationTokenSource.IsCancellationRequested)
        {
            Memory<byte> buffer = memoryOwner.Memory[..4096];

            try
            {
                int bytesReceived = await socket.ReceiveFromAsync(buffer, SocketFlags.None, receivedAddress, linkedCancellationTokenSource.Token).ConfigureAwait(false);
                var endPoint = (IPEndPoint)new IPEndPoint(0L, 0).Create(receivedAddress);

                responses.Add((endPoint.Address, Encoding.UTF8.GetString(buffer.Span[..bytesReceived])));
            }
            catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
            {
            }
        }

        return responses.ToFrozenSet();
    }

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

    private Uri? GetPreferredLocation(IReadOnlyCollection<Uri?> secureLocations, IReadOnlyCollection<Uri?> locations)
        => secureLocations.FirstOrDefault(q => Socket.OSSupportsIPv6 && q?.HostNameType is UriHostNameType.IPv6 && !networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? secureLocations.FirstOrDefault(q => Socket.OSSupportsIPv6 && q?.HostNameType is UriHostNameType.IPv6 && networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? secureLocations.FirstOrDefault(q => Socket.OSSupportsIPv4 && q?.HostNameType is UriHostNameType.IPv4)
            ?? locations.FirstOrDefault(q => Socket.OSSupportsIPv6 && q?.HostNameType is UriHostNameType.IPv6 && !networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? locations.FirstOrDefault(q => Socket.OSSupportsIPv6 && q?.HostNameType is UriHostNameType.IPv6 && networkService.IsPrivateIpAddress(IPAddress.Parse(q.IdnHost)))
            ?? locations.FirstOrDefault(q => Socket.OSSupportsIPv4 && q?.HostNameType is UriHostNameType.IPv4);

    private Uri? ParseLocation((IPAddress LocalIpAddress, Uri? Location) location) =>
        location.Location?.HostNameType is not UriHostNameType.IPv6 || !IPAddress.TryParse(location.Location.IdnHost, out IPAddress? ipAddress) || !networkService.IsPrivateIpAddress(ipAddress)
            ? location.Location
            : networkService.FormatUri(new(IPAddress.Parse(FormattableString.Invariant($"{location.Location.IdnHost}%{location.LocalIpAddress.ScopeId}")), location.Location.Port), location.Location.Scheme, location.Location.PathAndQuery);

    private async Task<(IPAddress IpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)> SearchDevicesAsync(IPAddress localAddress, IPAddress multicastAddress, string deviceType, int sendCount, int receiveTimeout, CancellationToken cancellationToken)
    {
        FrozenSet<(IPAddress IPAddress, string Response)> responses = [];
        var localEndPoint = new IPEndPoint(localAddress, 0);
        using var socket = new Socket(localAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

        socket.Bind(localEndPoint);

        var multiCastIpEndPoint = new IPEndPoint(multicastAddress, UPnPConstants.MultiCastPort);
        string request = FormattableString.Invariant($"M-SEARCH * HTTP/1.1\r\nHOST: {networkService.FormatUri(multiCastIpEndPoint).Authority}\r\nMAN: \"ssdp:discover\"\r\nMX: {receiveTimeout}\r\nST: {deviceType}\r\nCPFN.UPNP.ORG: RS.Fritz.Manager\r\n\r\n");
        const int charSize = sizeof(char);
        int bufferSize = request.Length * charSize;
        using IMemoryOwner<byte> memoryOwner = MemoryPool<byte>.Shared.Rent(bufferSize);
        Memory<byte> buffer = memoryOwner.Memory[..bufferSize];
        int bytes = Encoding.UTF8.GetBytes(request.AsSpan(), buffer.Span);

        buffer = buffer[..bytes];

        SocketAddress multiCastSocketAddress = multiCastIpEndPoint.Serialize();

        try
        {
            for (int i = 0; i < sendCount; i++)
            {
                _ = await socket.SendToAsync(buffer, SocketFlags.None, multiCastSocketAddress, cancellationToken).ConfigureAwait(false);
            }

            responses = await ReceiveAsync(socket, receiveTimeout, cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (!cancellationToken.IsCancellationRequested)
        {
        }

        return new(localAddress, responses);
    }

    private async Task<IEnumerable<(IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)>> GetRawDeviceResponses(string deviceType, int sendCount, int timeout, CancellationToken cancellationToken)
    {
        IEnumerable<IPAddress> unicastAddresses = networkService.GetUnicastAddresses();
        IEnumerable<IPAddress> multicastAddresses = networkService.GetMulticastAddresses();
        (IPAddress LocalIpAddress, FrozenSet<(IPAddress IPAddress, string Response)> Responses)[] localAddressesDeviceResponses = await TaskExtensions.WhenAllSafe(multicastAddresses.SelectMany(q => unicastAddresses.Where(r => r.AddressFamily == q.AddressFamily).Select(r => SearchDevicesAsync(r, q, deviceType, sendCount, timeout, cancellationToken)))).ConfigureAwait(false);

        return localAddressesDeviceResponses.Where(q => q.Responses.Any(r => r.Response.Length is not 0)).Select(q => (q.LocalIpAddress, q.Responses)).Distinct();
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
        var internetGatewayDevices = new List<InternetGatewayDevice>();

        foreach (UsnDeviceResponse usnDeviceResponse in serverDeviceResponse.UsnDeviceResponses)
        {
            var locations = usnDeviceResponse.DeviceSearchResponses.Where(r => r.Location is not null).Select(r => (r.IpAddress, r.Location)).Distinct().Select(ParseLocation).ToFrozenSet();
            var secureLocations = usnDeviceResponse.DeviceSearchResponses.Where(r => r.SecureLocation is not null).Select(r => (r.IpAddress, r.SecureLocation)).Distinct().Select(ParseLocation).ToFrozenSet();
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
                    if (preferredLocation.HostNameType is UriHostNameType.IPv6 && Socket.OSSupportsIPv4 && locations.Any(q => q?.HostNameType is UriHostNameType.IPv4))
                    {
                        try
                        {
                            preferredLocation = locations.First(q => q?.HostNameType is UriHostNameType.IPv4);
                            description = await GetUPnPDescription(preferredLocation!, serverDeviceResponse.UsnDeviceResponses.Select(q => q.Usn).Distinct().Single()!, cancellationToken).ConfigureAwait(false);
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
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.CacheControl).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.Date).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.Ext).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.Location),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.Server).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.SearchTarget).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.Usn).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.Opt).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.Nls).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.BootId).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.ConfigId).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.SearchPort).Distinct().SingleOrDefault(),
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.SecureLocation),
                description,
                preferredLocation,
                usnDeviceResponse.DeviceSearchResponses.Select(r => r.LocalIpAddress).ToFrozenSet(),
                ushort.TryParse(usnDeviceResponse.DeviceSearchResponses.Select(r => r.Usn).Distinct().SingleOrDefault()?[..1], out ushort version) ? version : null));
        }

        return new(
            internetGatewayDevices.SelectMany(q => q.Locations ?? []),
            serverDeviceResponse.Server,
            internetGatewayDevices,
            internetGatewayDevices.MaxBy(q => q.Version)?.PreferredLocation,
            serverDeviceResponse.IpAddresses);
    }
}
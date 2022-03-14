namespace RS.Fritz.Manager.API;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

internal sealed class DeviceSearchService : IDeviceSearchService
{
    private const string InternetGatewayDeviceDeviceType = "urn:dslforum-org:device:InternetGatewayDevice:1";
    private const int UPnPMultiCastPort = 1900;
    private const int DefaultReceiveTimeout = 500;
    private const int DefaultSendCount = 3;
#pragma warning disable SA1310 // Field names should not contain underscore
    private const uint IOC_IN = 0x80000000;
    private const uint IOC_VENDOR = 0x18000000;
    private const uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12; // This ioctl queries the underlying provider for a handle that can be used to receive plug and play event notifications.
#pragma warning restore SA1310 // Field names should not contain underscore

    private readonly IHttpClientFactory httpClientFactory;
    private readonly IFritzServiceOperationHandler fritzServiceOperationHandler;
    private readonly AddressFamily[] supportedAddressFamilies = { AddressFamily.InterNetwork, AddressFamily.InterNetworkV6 };

    public DeviceSearchService(IHttpClientFactory httpClientFactory, IFritzServiceOperationHandler fritzServiceOperationHandler)
    {
        this.httpClientFactory = httpClientFactory;
        this.fritzServiceOperationHandler = fritzServiceOperationHandler;
    }

    private static IDictionary<AddressType, IPAddress> SsdpMultiCastAddresses => new Dictionary<AddressType, IPAddress>
    {
        [AddressType.IPv4SiteLocal] = IPAddress.Parse("239.255.255.250"),
        [AddressType.IPv6LinkLocal] = IPAddress.Parse("[FF02::C]"),
        [AddressType.IPv6SiteLocal] = IPAddress.Parse("[FF05::C]")
    };

    public async Task<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string? deviceType = null, int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default)
    {
        deviceType ??= InternetGatewayDeviceDeviceType;
        timeout ??= DefaultReceiveTimeout;
        sendCount ??= DefaultSendCount;

        IEnumerable<string> deviceResponses = (await TaskExtensions.WhenAllSafe(GetLocalAddresses().Select(q => SearchDevicesAsync(q, deviceType, sendCount.Value, timeout.Value, cancellationToken)))).SelectMany(q => q);
        IEnumerable<Dictionary<string, string>> deviceDictionaries = GetDeviceDictionaries(deviceResponses);

        InternetGatewayDevice[] internetGatewayDevices = deviceDictionaries
            .Select(q => new InternetGatewayDeviceResponse(new Uri(q["LOCATION"]), q["SERVER"], q["CACHE-CONTROL"], q["EXT"], q["ST"], q["USN"]))
            .GroupBy(q => q.Usn)
            .Select(GetInternetGatewayDevice)
            .ToArray();

        await TaskExtensions.WhenAllSafe(internetGatewayDevices.Select(q => GetUPnPDescription(q, cancellationToken)));

        return internetGatewayDevices;
    }

    private static Uri GetPreferredLocation(IGrouping<string, InternetGatewayDeviceResponse> internetGatewayDeviceResponses)
    {
        return internetGatewayDeviceResponses.Select(q => q.Location).Distinct().SingleOrDefault(q => q.HostNameType is UriHostNameType.IPv6) ?? internetGatewayDeviceResponses.Select(q => q.Location).Distinct().Single(q => q.HostNameType is UriHostNameType.IPv4);
    }

    private static IEnumerable<Dictionary<string, string>> GetDeviceDictionaries(IEnumerable<string> responses)
    {
        return responses.Select(q => q.Split(Environment.NewLine)).Select(q => q.Where(r => r.Contains(':', StringComparison.OrdinalIgnoreCase)).ToDictionary(
            s => s[..s.IndexOf(':', StringComparison.OrdinalIgnoreCase)],
            s =>
            {
                string value = s[s.IndexOf(':', StringComparison.OrdinalIgnoreCase)..];

                if (value.EndsWith(":", StringComparison.OrdinalIgnoreCase))
                    return value.Replace(":", null, StringComparison.OrdinalIgnoreCase);

                return value.Replace(": ", null, StringComparison.OrdinalIgnoreCase);
            }));
    }

    private static async Task<IEnumerable<string>> SearchDevicesAsync(IPAddress localAddress, string deviceType, int sendCount, int receiveTimeout, CancellationToken cancellationToken)
    {
        var responses = new List<string>();
        AddressType addressType = GetAddressType(localAddress);

        if (addressType is AddressType.Unknown)
            return responses;

        using var socket = new Socket(localAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

        socket.ExclusiveAddressUse = true;

        if (OperatingSystem.IsWindows())
            _ = socket.IOControl(unchecked((int)SIO_UDP_CONNRESET), new byte[] { 0 }, null); // Disables ICMP errors to be propagated to the socket.

        socket.Bind(new IPEndPoint(localAddress, 0));

        var multiCastIpEndPoint = new IPEndPoint(SsdpMultiCastAddresses[addressType], UPnPMultiCastPort);
        string request = FormattableString.Invariant($"M-SEARCH * HTTP/1.1\r\nHOST: {multiCastIpEndPoint}\r\nST: {deviceType}\r\nMAN: \"ssdp:discover\"\r\nMX: 3\r\n\r\n");
        var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(request));

        for (int i = 0; i < sendCount; i++)
        {
            _ = await socket.SendToAsync(buffer, SocketFlags.None, multiCastIpEndPoint);
        }

        await ReceiveAsync(socket, new ArraySegment<byte>(new byte[4096]), responses, receiveTimeout, cancellationToken);

        return responses;
    }

    private static AddressType GetAddressType(IPAddress localAddress)
    {
        if (localAddress.AddressFamily == AddressFamily.InterNetwork)
            return AddressType.IPv4SiteLocal;

        if (localAddress.IsIPv6LinkLocal)
            return AddressType.IPv6LinkLocal;

        if (localAddress.IsIPv6SiteLocal)
            return AddressType.IPv6SiteLocal;

        return AddressType.Unknown;
    }

    private static async Task ReceiveAsync(Socket socket, ArraySegment<byte> buffer, ICollection<string> responses, int receiveTimeout, CancellationToken cancellationToken)
    {
        using var timeoutCancellationTokenSource = new CancellationTokenSource(receiveTimeout);
        using var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(timeoutCancellationTokenSource.Token, cancellationToken);

        while (!linkedCancellationTokenSource.IsCancellationRequested)
        {
            try
            {
                int bytesReceived = await socket.ReceiveAsync(buffer, SocketFlags.None, linkedCancellationTokenSource.Token);

                if (bytesReceived > 0)
                    responses.Add(Encoding.UTF8.GetString(buffer.Take(bytesReceived).ToArray()));
            }
            catch (OperationCanceledException)
            {
                // Ignore Task cancellation
            }
        }
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

    private async Task GetUPnPDescription(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken)
    {
        Uri uri = internetGatewayDevice.Locations.SingleOrDefault(r => r.HostNameType == UriHostNameType.IPv6) ?? internetGatewayDevice.Locations.Single(r => r.HostNameType == UriHostNameType.IPv4);
        string uPnPDescription = await httpClientFactory.CreateClient(Constants.HttpClientName).GetStringAsync(uri, cancellationToken);
        using var stringReader = new StringReader(uPnPDescription);
        using var xmlTextReader = new XmlTextReader(stringReader);

        internetGatewayDevice.UPnPDescription = (UPnPDescription?)new DataContractSerializer(typeof(UPnPDescription)).ReadObject(xmlTextReader);
    }

    private InternetGatewayDevice GetInternetGatewayDevice(IGrouping<string, InternetGatewayDeviceResponse> internetGatewayDeviceResponses)
    {
        return new InternetGatewayDevice(
            fritzServiceOperationHandler,
            internetGatewayDeviceResponses.Select(r => r.Location).Distinct(),
            internetGatewayDeviceResponses.Select(r => r.Server).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.CacheControl).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.Ext).Distinct().Single(),
            internetGatewayDeviceResponses.Select(r => r.SearchTarget).Distinct().Single(),
            internetGatewayDeviceResponses.Key,
            GetPreferredLocation(internetGatewayDeviceResponses));
    }
}
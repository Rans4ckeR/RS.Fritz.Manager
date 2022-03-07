namespace RS.Fritz.Manager.API
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;

    internal sealed class DeviceSearchService : IDeviceSearchService
    {
        private const string InternetGatewayDeviceDeviceType = "urn:dslforum-org:device:InternetGatewayDevice:1";
        private const int UPnPMulticastPort = 1900;
        private const int ReceiveTimeout = 3000;
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

        private static IDictionary<AddressType, IPAddress> SsdpMulticastAddresses => new Dictionary<AddressType, IPAddress>
        {
            [AddressType.IPv4SiteLocal] = IPAddress.Parse("239.255.255.250"),
            [AddressType.IPv6LinkLocal] = IPAddress.Parse("[FF02::C]"),
            [AddressType.IPv6SiteLocal] = IPAddress.Parse("[FF05::C]")
        };

        public async Task<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string? deviceType = null)
        {
            if (deviceType is null)
                deviceType = InternetGatewayDeviceDeviceType;

            IEnumerable<string> deviceResponses = (await TaskExtensions.WhenAllSafe(GetLocalAddresses().Select(q => SearchDevicesAsync(q, deviceType, 3)))).SelectMany(q => q);
            IEnumerable<Dictionary<string, string>> deviceDictionaries = GetDeviceDictionaries(deviceResponses);

            InternetGatewayDevice[] internetGatewayDevices = deviceDictionaries
                .Select(q => new InternetGatewayDeviceResponse(new Uri(q["LOCATION"]), q["SERVER"], q["CACHE-CONTROL"], q["EXT"], q["ST"], q["USN"]))
                .GroupBy(q => q.Usn)
                .Select(q => new InternetGatewayDevice(fritzServiceOperationHandler, q.Select(r => r.Location).Distinct(), q.Select(r => r.Server).Distinct().Single(), q.Select(r => r.CacheControl).Distinct().Single(), q.Select(r => r.Ext).Distinct().Single(), q.Select(r => r.SearchTarget).Distinct().Single(), q.Key, q.Select(r => r.Location).Distinct().SingleOrDefault(r => r.HostNameType is UriHostNameType.IPv6) ?? q.Select(r => r.Location).Distinct().Single(r => r.HostNameType is UriHostNameType.IPv4)))
                .ToArray();

            await TaskExtensions.WhenAllSafe(internetGatewayDevices.Select(GetUPnPDescription));

            return internetGatewayDevices;
        }

        private static IEnumerable<Dictionary<string, string>> GetDeviceDictionaries(IEnumerable<string> responses)
        {
            return responses.Select(q => q.Split(Environment.NewLine)).Select(q => q.Where(r => r.Contains(':')).ToDictionary(
                s => s[..s.IndexOf(':')],
                s =>
                {
                    string value = s[s.IndexOf(':')..];

                    if (value.EndsWith(':'))
                        return value.Replace(":", null);

                    return value.Replace(": ", null);
                }));
        }

        private static async Task<IEnumerable<string>> SearchDevicesAsync(IPAddress localAddress, string deviceType, int sendCount)
        {
            var responses = new List<string>();
            AddressType addressType = GetAddressType(localAddress);

            if (addressType is AddressType.Unknown)
                return responses;

            using var socket = new Socket(localAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

            socket.ExclusiveAddressUse = true;

            if (OperatingSystem.IsWindows())
                socket.IOControl(unchecked((int)SIO_UDP_CONNRESET), new byte[] { 0 }, null); // Disables ICMP errors to be propagated to the socket.

            socket.Bind(new IPEndPoint(localAddress, 0));

            var multicastIPEndPoint = new IPEndPoint(SsdpMulticastAddresses[addressType], UPnPMulticastPort);
            string request = FormattableString.Invariant($"M-SEARCH * HTTP/1.1\r\nHOST: {multicastIPEndPoint}\r\nST: {deviceType}\r\nMAN: \"ssdp:discover\"\r\nMX: 3\r\n\r\n");
            var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(request));

            for (int i = 0; i < sendCount; i++)
            {
                await socket.SendToAsync(buffer, SocketFlags.None, multicastIPEndPoint);
            }

            await ReceiveAsync(socket, new ArraySegment<byte>(new byte[4096]), responses);

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

        private static async Task ReceiveAsync(Socket socket, ArraySegment<byte> buffer, ICollection<string> responses)
        {
            using var cancellationTokenSource = new CancellationTokenSource();

            cancellationTokenSource.CancelAfter(ReceiveTimeout);

            while (!cancellationTokenSource.IsCancellationRequested)
            {
                try
                {
                    int bytesReceived = await socket.ReceiveAsync(buffer, SocketFlags.None, cancellationTokenSource.Token);

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

        private async Task GetUPnPDescription(InternetGatewayDevice internetGatewayDevice)
        {
            Uri uri = internetGatewayDevice.Locations.SingleOrDefault(r => r.HostNameType == UriHostNameType.IPv6) ?? internetGatewayDevice.Locations.Single(r => r.HostNameType == UriHostNameType.IPv4);
            string uPnPDescription = await httpClientFactory.CreateClient(Constants.HttpClientName).GetStringAsync(uri);
            using var stringReader = new StringReader(uPnPDescription);
            using var xmlTextReader = new XmlTextReader(stringReader);

            internetGatewayDevice.UPnPDescription = (UPnPDescription?)new XmlSerializer(typeof(UPnPDescription)).Deserialize(xmlTextReader);
        }
    }
}
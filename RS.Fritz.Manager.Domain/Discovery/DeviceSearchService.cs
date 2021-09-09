namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;

    public sealed class DeviceSearchService : IDeviceSearchService
    {
        private const int UPnPMulticastPort = 1900;
        private const int ReceiveTimeout = 3000;
#pragma warning disable SA1310 // Field names should not contain underscore
        private const uint IOC_IN = 0x80000000;
        private const uint IOC_VENDOR = 0x18000000;
        private const uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
#pragma warning restore SA1310 // Field names should not contain underscore

        private readonly IHttpClientFactory httpClientFactory;
        private readonly AddressFamily[] supportedAddressFamilies = new[] { AddressFamily.InterNetwork, AddressFamily.InterNetworkV6 };

        public DeviceSearchService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        private static IDictionary<AddressType, string> MulticastAddresses => new Dictionary<AddressType, string>
        {
            [AddressType.IPv4] = "239.255.255.250",
            [AddressType.IPv6LinkLocal] = "[FF02::C]",
            [AddressType.IPv6SiteLocal] = "[FF05::C]"
        };

        public async Task<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string deviceType)
        {
            IEnumerable<string> responses = (await TaskExtensions.WhenAllSafe(GetLocalAddresses().Select(q => SearchDevicesAsync(q, deviceType, 3)))).SelectMany(q => q);
            IEnumerable<Dictionary<string, string>> dictionaries = responses.Select(q => q.Split(Environment.NewLine)).Select(q => q.Where(r => r.Contains(": ")).ToDictionary(r => r.Split(": ")[0], r => r.Split(": ")[1]));

            InternetGatewayDevice[] internetGatewayDevices = dictionaries.Select(q => new InternetGatewayDeviceResponse
            {
                CacheControl = q.TryGetValue("CACHE-CONTROL", out string? cacheControl) ? cacheControl : default,
                Ext = q.TryGetValue("EXT", out string? ext) ? ext : default,
                Location = q.TryGetValue("LOCATION", out string? location) ? new Uri(location) : default,
                Server = q.TryGetValue("SERVER", out string? server) ? server : default,
                SearchTarget = q.TryGetValue("ST", out string? st) ? st : default,
                Usn = q.TryGetValue("USN", out string? usn) ? usn : default
            }).GroupBy(q => q.Usn).Select(q => new InternetGatewayDevice
            {
                CacheControl = q.Select(r => r.CacheControl).Distinct().Single(),
                Ext = q.Select(r => r.Ext).Distinct().Single(),
                Locations = q.Select(r => r.Location!).Distinct(),
                Server = q.Select(r => r.Server).Distinct().Single(),
                SearchTarget = q.Select(r => r.SearchTarget).Distinct().Single(),
                UniqueServiceName = q.Key
            }).ToArray();

            await TaskExtensions.WhenAllSafe(internetGatewayDevices.Select(GetUPnPDescription));

            return internetGatewayDevices;
        }

        private static async Task<IEnumerable<string>> SearchDevicesAsync(IPAddress localAddress, string deviceType, int sendCount)
        {
            var responses = new List<string>();
            AddressType addressType = GetAddressType(localAddress);

            if (addressType is AddressType.Unknown)
                return responses;

            using var socket = new Socket(localAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

            socket.ExclusiveAddressUse = true;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                socket.IOControl(unchecked((int)SIO_UDP_CONNRESET), new[] { Convert.ToByte(false) }, null);

            socket.Bind(new IPEndPoint(localAddress, 0));

            var multicastIPEndPoint = new IPEndPoint(IPAddress.Parse(MulticastAddresses[addressType]), UPnPMulticastPort);
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
                return AddressType.IPv4;

            if (localAddress.IsIPv6LinkLocal)
                return AddressType.IPv6LinkLocal;

            if (localAddress.IsIPv6SiteLocal)
                return AddressType.IPv6SiteLocal;

            return AddressType.Unknown;
        }

        private static async Task ReceiveAsync(Socket socket, ArraySegment<byte> buffer, ICollection<string> responses)
        {
            var cancellationTokenSource = new CancellationTokenSource();

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

            cancellationTokenSource.Dispose();
        }

        private IEnumerable<IPAddress> GetLocalAddresses()
        {
            return NetworkInterface.GetAllNetworkInterfaces()
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
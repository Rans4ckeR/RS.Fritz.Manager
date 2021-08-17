namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed partial class DeviceSearchService : IDeviceSearchService
    {
        private const int UPnPMulticastPort = 1900;
        private const int ReceiveTimeout = 3000;
#pragma warning disable SA1310 // Field names should not contain underscore
        private const uint IOC_IN = 0x80000000;
        private const uint IOC_VENDOR = 0x18000000;
        private const uint SIO_UDP_CONNRESET = IOC_IN | IOC_VENDOR | 12;
#pragma warning restore SA1310 // Field names should not contain underscore

        private static IDictionary<AddressType, string> MulticastAddresses => new Dictionary<AddressType, string>
        {
            [AddressType.IPv4] = "239.255.255.250",
            [AddressType.IPv6LinkLocal] = "[FF02::C]",
            [AddressType.IPv6SiteLocal] = "[FF05::C]",
        };

        public async Task<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string deviceType)
        {
            IEnumerable<string> responses = (await Task.WhenAll(GetLocalAddresses().Select(q => SearchDevicesAsync(q, deviceType, 3)))).SelectMany(q => q);
            IEnumerable<Dictionary<string, string>> dictionaries = responses.Select(q => q.Split(Environment.NewLine)).Select(q => q.Where(q => q.Contains(": ")).ToDictionary(r => r.Split(": ")[0], r => r.Split(": ")[1]));

            return dictionaries.Select(q => new InternetGatewayDeviceResponse
            {
                CacheControl = q.TryGetValue("CACHE-CONTROL", out string? cacheControl) ? cacheControl : default,
                Ext = q.TryGetValue("EXT", out string? ext) ? ext : default,
                Location = q.TryGetValue("LOCATION", out string? location) ? new Uri(location) : default,
                Server = q.TryGetValue("SERVER", out string? server) ? server : default,
                St = q.TryGetValue("ST", out string? st) ? st : default,
                Usn = q.TryGetValue("USN", out string? usn) ? usn : default
            }).GroupBy(q => q.Usn).Select(q => new InternetGatewayDevice
            {
                CacheControl = q.Select(r => r.CacheControl).Distinct().Single(),
                Ext = q.Select(r => r.Ext).Distinct().Single(),
                Locations = q.Select(r => r.Location!).Distinct(),
                Server = q.Select(r => r.Server).Distinct().Single(),
                ServiceType = q.Select(r => r.St).Distinct().Single(),
                UniqueServiceName = q.Key
            });
        }

        private static IEnumerable<IPAddress> GetLocalAddresses()
        {
            return NetworkInterface.GetAllNetworkInterfaces()
                .Select(ni => ni.GetIPProperties())
                .Where(p => p.GatewayAddresses != null && p.GatewayAddresses.Any())
                .SelectMany(p => p.UnicastAddresses)
                .Select(aInfo => aInfo.Address)
                .Where(a => a.AddressFamily == AddressFamily.InterNetwork || a.AddressFamily == AddressFamily.InterNetworkV6);
        }

        private static async Task<IEnumerable<string>> SearchDevicesAsync(IPAddress localAddress, string deviceType, int sendCount)
        {
            var responses = new List<string>();
            AddressType addressType = GetAddressType(localAddress);

            if (addressType is AddressType.Unknown)
                return responses;

            try
            {
                using var socket = new Socket(localAddress.AddressFamily, SocketType.Dgram, ProtocolType.Udp);

                socket.ExclusiveAddressUse = true;

                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    socket.IOControl(unchecked((int)SIO_UDP_CONNRESET), new[] { Convert.ToByte(false) }, null);

                socket.Bind(new IPEndPoint(localAddress, 0));

                var multicastIPEndPoint = new IPEndPoint(IPAddress.Parse(MulticastAddresses[addressType]), UPnPMulticastPort);
                string req = FormattableString.Invariant($"M-SEARCH * HTTP/1.1\r\nHOST: {multicastIPEndPoint}\r\nST: {deviceType}\r\nMAN: \"ssdp:discover\"\r\nMX: 3\r\n\r\n");
                var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(req));

                for (int i = 0; i < sendCount; i++)
                {
                    await socket.SendToAsync(buffer, SocketFlags.None, multicastIPEndPoint);
                }

                await ReceiveAsync(socket, new ArraySegment<byte>(new byte[4096]), responses);
            }
            catch (OperationCanceledException)
            {
                // Ignore Task cancellation
            }

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
            while (true)
            {
                var cancellationTokenSource = new CancellationTokenSource();
                int i;

                try
                {
                    cancellationTokenSource.CancelAfter(ReceiveTimeout);

                    i = await socket.ReceiveAsync(buffer, SocketFlags.None, cancellationTokenSource.Token);
                }
                finally
                {
                    cancellationTokenSource.Dispose();
                }

                if (i > 0)
                    responses.Add(Encoding.UTF8.GetString(buffer.Take(i).ToArray()));
            }
        }
    }
}
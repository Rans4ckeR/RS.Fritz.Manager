namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed record InternetGatewayDevice
    {
        public InternetGatewayDevice()
        {
            Locations = Enumerable.Empty<Uri>();
        }

        public IEnumerable<Uri> Locations { get; set; }

        public string? Server { get; set; }

        public string? CacheControl { get; set; }

        public string? Ext { get; set; }

        public string? SearchTarget { get; set; }

        // the last 48 bits are the Customer Premises Equipment (CPE)’s LAN MAC address
        public string? UniqueServiceName { get; set; }

        public ushort? SecurityPort { get; set; }

        public Uri PreferredLocation
        {
            get
            {
                Uri? location = Locations.SingleOrDefault(r => r.HostNameType is UriHostNameType.IPv6);

                if (location is null)
                    return Locations.Single(r => r.HostNameType is UriHostNameType.IPv4);

                return location;
            }
        }

        public UPnPDescription? UPnPDescription { get; set; }
    }
}
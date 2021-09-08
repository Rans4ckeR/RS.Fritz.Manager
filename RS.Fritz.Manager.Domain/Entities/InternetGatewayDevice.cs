namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public sealed record InternetGatewayDevice
    {
        private IEnumerable<Uri> locations;

        public InternetGatewayDevice()
        {
            locations = Enumerable.Empty<Uri>();
        }

        public IEnumerable<Uri> Locations
        {
            get => locations;
            set
            {
                locations = value;
                PreferredLocation = GetPreferredLocation();
            }
        }

        public string? Server { get; set; }

        public string? CacheControl { get; set; }

        public string? Ext { get; set; }

        public string? SearchTarget { get; set; }

        public string? UniqueServiceName { get; set; }

        public ushort? SecurityPort { get; set; }

        public Uri? PreferredLocation { get; set; }

        public UPnPDescription? UPnPDescription { get; set; }

        private Uri? GetPreferredLocation()
        {
            Uri? location = Locations.SingleOrDefault(r => r.HostNameType is UriHostNameType.IPv6);

            if (location is not null)
                return location;

            return Locations.SingleOrDefault(r => r.HostNameType is UriHostNameType.IPv4);
        }
    }
}
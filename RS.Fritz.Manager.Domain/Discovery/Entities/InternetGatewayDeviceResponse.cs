namespace RS.Fritz.Manager.Domain
{
    using System;

    internal sealed record InternetGatewayDeviceResponse
    {
        public Uri? Location { get; set; }

        public string? Server { get; set; }

        public string? CacheControl { get; set; }

        public string? Ext { get; set; }

        public string? SearchTarget { get; set; }

        public string? Usn { get; set; }
    }
}
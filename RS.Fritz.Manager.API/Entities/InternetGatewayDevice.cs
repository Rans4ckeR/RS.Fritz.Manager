namespace RS.Fritz.Manager.API
{
    using System;
    using System.Collections.Generic;

    public sealed record InternetGatewayDevice(IEnumerable<Uri> Locations, string Server, string CacheControl, string? Ext, string SearchTarget, string UniqueServiceName, Uri PreferredLocation)
    {
        public UPnPDescription? UPnPDescription { get; set; }

        public ushort? SecurityPort { get; set; }
    }
}
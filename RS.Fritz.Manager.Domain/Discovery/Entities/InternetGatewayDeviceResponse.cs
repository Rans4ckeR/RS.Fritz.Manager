namespace RS.Fritz.Manager.Domain
{
    using System;

    internal sealed record InternetGatewayDeviceResponse(Uri Location, string Server, string CacheControl, string Ext, string SearchTarget, string Usn);
}
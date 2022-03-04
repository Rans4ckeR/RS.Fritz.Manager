namespace RS.Fritz.Manager.API
{
    using System;

    internal sealed record InternetGatewayDeviceResponse(Uri Location, string Server, string CacheControl, string Ext, string SearchTarget, string Usn);
}
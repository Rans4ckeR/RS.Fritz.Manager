namespace RS.Fritz.Manager.API;

using System;
using System.Net;

internal readonly record struct InternetGatewayDeviceResponse(Uri Location, string Server, string CacheControl, string Ext, string SearchTarget, string Usn, IPAddress LocalIpAddress);
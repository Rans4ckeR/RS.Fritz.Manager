namespace RS.Fritz.Manager.API;

using System;
using System.Net;

public readonly record struct DeviceSearchResponse(
    string? CacheControl,
    string? Date,
    string? Ext,
    Uri? Location,
    string? Server,
    string? SearchTarget,
    string? Usn,
    string? Opt,
    string? Nls,
    int? BootId,
    int? ConfigId,
    ushort? SearchPort,
    Uri? SecureLocation,
    IPAddress IpAddress,
    IPAddress LocalIpAddress);
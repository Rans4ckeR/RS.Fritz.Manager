using System.Net;

namespace RS.Fritz.Manager.API;

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
namespace RS.Fritz.Manager.API;

using System.Collections.Frozen;
using System.Net;

public readonly record struct ServerDeviceResponse(string? Server, FrozenSet<IPAddress> IpAddresses, FrozenSet<UsnDeviceResponse> UsnDeviceResponses);
using System.Collections.Frozen;
using System.Net;

namespace RS.Fritz.Manager.API;

public readonly record struct ServerDeviceResponse(string? Server, FrozenSet<IPAddress> IpAddresses, FrozenSet<UsnDeviceResponse> UsnDeviceResponses);
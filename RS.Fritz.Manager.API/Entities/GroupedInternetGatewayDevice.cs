using System.Collections.Frozen;
using System.Net;

namespace RS.Fritz.Manager.API;

public sealed record GroupedInternetGatewayDevice(
    IEnumerable<Uri?>? Locations,
    string? Server,
    IEnumerable<InternetGatewayDevice> Devices,
    Uri? PreferredLocation,
    FrozenSet<IPAddress> LocalIpAddresses);
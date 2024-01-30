namespace RS.Fritz.Manager.API;

using System.Collections.Frozen;
using System.Net;

public sealed record GroupedInternetGatewayDevice(
    IEnumerable<Uri?>? Locations,
    string? Server,
    IEnumerable<InternetGatewayDevice> Devices,
    Uri? PreferredLocation,
    FrozenSet<IPAddress> LocalIpAddresses);
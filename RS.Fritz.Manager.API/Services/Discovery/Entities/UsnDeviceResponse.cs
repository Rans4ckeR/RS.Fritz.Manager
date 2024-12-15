using System.Collections.Frozen;

namespace RS.Fritz.Manager.API;

public readonly record struct UsnDeviceResponse(string? Server, string? Usn, FrozenSet<DeviceSearchResponse> DeviceSearchResponses);
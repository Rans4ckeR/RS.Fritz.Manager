namespace RS.Fritz.Manager.API;

using System.Collections.Frozen;

public readonly record struct UsnDeviceResponse(string? Server, string? Usn, FrozenSet<DeviceSearchResponse> DeviceSearchResponses);
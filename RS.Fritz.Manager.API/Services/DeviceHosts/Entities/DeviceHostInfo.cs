namespace RS.Fritz.Manager.API;

public readonly record struct DeviceHostInfo(string HostListPath, Uri HostListPathLink, IEnumerable<DeviceHost> DeviceHosts);
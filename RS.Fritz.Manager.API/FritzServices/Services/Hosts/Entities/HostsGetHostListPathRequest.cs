namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetHostListPath")]
public readonly record struct HostsGetHostListPathRequest;
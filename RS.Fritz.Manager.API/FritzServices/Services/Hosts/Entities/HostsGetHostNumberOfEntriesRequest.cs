namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetHostNumberOfEntries")]
public readonly record struct HostsGetHostNumberOfEntriesRequest;
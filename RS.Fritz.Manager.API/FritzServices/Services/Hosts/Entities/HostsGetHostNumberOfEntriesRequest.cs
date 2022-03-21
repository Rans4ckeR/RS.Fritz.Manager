namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetHostNumberOfEntries")]
public readonly record struct HostsGetHostNumberOfEntriesRequest;
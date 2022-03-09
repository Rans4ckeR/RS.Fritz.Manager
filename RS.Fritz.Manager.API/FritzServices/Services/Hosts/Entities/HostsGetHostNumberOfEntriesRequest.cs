namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetHostNumberOfEntries")]
public sealed record HostsGetHostNumberOfEntriesRequest;
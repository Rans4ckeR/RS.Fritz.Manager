namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetHostNumberOfEntriesResponse")]
public readonly record struct HostsGetHostNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewHostNumberOfEntries")] ushort HostNumberOfEntries);
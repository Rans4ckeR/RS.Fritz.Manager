namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetHostNumberOfEntriesResponse")]
public readonly record struct HostsGetHostNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewHostNumberOfEntries")] ushort HostNumberOfEntries);
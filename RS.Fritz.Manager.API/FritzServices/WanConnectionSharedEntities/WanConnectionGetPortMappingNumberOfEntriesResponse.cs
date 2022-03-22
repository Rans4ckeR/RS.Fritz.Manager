namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetPortMappingNumberOfEntriesResponse")]
public readonly record struct WanConnectionGetPortMappingNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewPortMappingNumberOfEntries")] ushort PortMappingNumberOfEntries);
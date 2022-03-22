namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetGenericPortMappingEntry")]
public readonly record struct WanConnectionGetGenericPortMappingEntryRequest(
    [property: MessageBodyMember(Name = "NewPortMappingIndex")] ushort PortMappingIndex);
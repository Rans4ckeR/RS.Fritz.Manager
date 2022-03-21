namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetGenericPortMappingEntry")]
public readonly record struct WanConnectionGetGenericPortMappingEntryRequest(
    [property: MessageBodyMember(Name = "NewPortMappingIndex")] ushort PortMappingIndex);
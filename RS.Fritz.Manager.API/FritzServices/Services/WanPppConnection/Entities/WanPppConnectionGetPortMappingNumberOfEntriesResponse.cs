namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetPortMappingNumberOfEntriesResponse")]
public readonly record struct WanPppConnectionGetPortMappingNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewPortMappingNumberOfEntries")] ushort PortMappingNumberOfEntries);
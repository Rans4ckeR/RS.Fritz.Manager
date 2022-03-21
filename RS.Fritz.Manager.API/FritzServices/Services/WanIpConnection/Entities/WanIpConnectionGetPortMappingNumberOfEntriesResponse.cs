namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetPortMappingNumberOfEntriesResponse")]
public readonly record struct WanIpConnectionGetPortMappingNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewPortMappingNumberOfEntries")] ushort PortMappingNumberOfEntries);
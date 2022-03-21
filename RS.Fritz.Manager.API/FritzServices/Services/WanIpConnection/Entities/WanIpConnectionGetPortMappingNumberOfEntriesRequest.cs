namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetPortMappingNumberOfEntries")]
public readonly record struct WanIpConnectionGetPortMappingNumberOfEntriesRequest;
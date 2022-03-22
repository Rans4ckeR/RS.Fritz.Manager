namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetPortMappingNumberOfEntries")]
public readonly record struct WanConnectionGetPortMappingNumberOfEntriesRequest;
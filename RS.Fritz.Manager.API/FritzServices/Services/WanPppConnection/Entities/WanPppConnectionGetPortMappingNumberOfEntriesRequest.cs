namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetPortMappingNumberOfEntries")]
public sealed record WanPppConnectionGetPortMappingNumberOfEntriesRequest;
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetForwardNumberOfEntries")]
public readonly record struct Layer3ForwardingGetForwardNumberOfEntriesRequest;
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetForwardNumberOfEntries")]
public sealed record Layer3ForwardingGetForwardNumberOfEntriesRequest;
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetChangeCounter")]
public readonly record struct HostsGetChangeCounterRequest;
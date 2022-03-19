namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetChangeCounter")]
public sealed record HostsGetChangeCounterRequest;
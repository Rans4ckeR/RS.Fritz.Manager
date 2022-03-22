namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetChangeCounter")]
public readonly record struct HostsGetChangeCounterRequest;
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetFriendlyName")]
public readonly record struct HostsGetFriendlyNameRequest;
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "DoUpdate")]
public readonly record struct UserInterfaceDoUpdateRequest;
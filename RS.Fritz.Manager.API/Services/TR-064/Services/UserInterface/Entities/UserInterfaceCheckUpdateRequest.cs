namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "CheckUpdate")]
public readonly record struct UserInterfaceCheckUpdateRequest;
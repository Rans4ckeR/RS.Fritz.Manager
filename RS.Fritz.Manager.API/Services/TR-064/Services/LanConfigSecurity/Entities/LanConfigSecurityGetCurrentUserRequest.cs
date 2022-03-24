namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetCurrentUser")]
public readonly record struct LanConfigSecurityGetCurrentUserRequest;
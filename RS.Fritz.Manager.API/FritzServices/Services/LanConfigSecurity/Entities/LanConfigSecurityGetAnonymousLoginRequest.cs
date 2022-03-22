namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetAnonymousLogin")]
public readonly record struct LanConfigSecurityGetAnonymousLoginRequest;
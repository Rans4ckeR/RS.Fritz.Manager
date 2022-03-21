namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAnonymousLogin")]
public readonly record struct LanConfigSecurityGetAnonymousLoginRequest;
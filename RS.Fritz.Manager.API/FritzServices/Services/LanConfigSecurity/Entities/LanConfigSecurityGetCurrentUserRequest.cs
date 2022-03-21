namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetCurrentUser")]
public readonly record struct LanConfigSecurityGetCurrentUserRequest;
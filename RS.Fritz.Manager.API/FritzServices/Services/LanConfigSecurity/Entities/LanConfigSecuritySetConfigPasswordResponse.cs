namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "SetConfigPasswordResponse")]
public readonly record struct LanConfigSecuritySetConfigPasswordResponse;
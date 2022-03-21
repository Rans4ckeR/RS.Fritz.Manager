namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "SetConfigPassword")]
public readonly record struct LanConfigSecuritySetConfigPasswordRequest(
    [property: MessageBodyMember(Name = "NewPassword")] string Password);
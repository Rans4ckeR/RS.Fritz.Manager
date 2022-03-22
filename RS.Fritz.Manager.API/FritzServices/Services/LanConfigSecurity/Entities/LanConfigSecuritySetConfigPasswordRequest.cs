namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetConfigPassword")]
public readonly record struct LanConfigSecuritySetConfigPasswordRequest(
    [property: MessageBodyMember(Name = "NewPassword")] string Password);
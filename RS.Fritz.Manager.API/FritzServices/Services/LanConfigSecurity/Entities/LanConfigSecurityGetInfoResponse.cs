namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct LanConfigSecurityGetInfoResponse(
    [property: MessageBodyMember(Name = "NewMaxCharsPassword")] ushort MaxCharsPassword,
    [property: MessageBodyMember(Name = "NewMinCharsPassword")] ushort MinCharsPassword,
    [property: MessageBodyMember(Name = "NewAllowedCharsPassword")] string AllowedCharsPassword);
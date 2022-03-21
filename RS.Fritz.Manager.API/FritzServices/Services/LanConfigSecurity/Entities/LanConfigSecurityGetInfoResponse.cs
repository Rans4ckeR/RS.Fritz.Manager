namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct LanConfigSecurityGetInfoResponse(
    [property: MessageBodyMember(Name = "NewMaxCharsPassword")] ushort MaxCharsPassword,
    [property: MessageBodyMember(Name = "NewMinCharsPassword")] ushort MinCharsPassword,
    [property: MessageBodyMember(Name = "NewAllowedCharsPassword")] string AllowedCharsPassword);
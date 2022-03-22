namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetAnonymousLoginResponse")]
public readonly record struct LanConfigSecurityGetAnonymousLoginResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AnonymousLoginEnabled")] bool AnonymousLoginEnabled);
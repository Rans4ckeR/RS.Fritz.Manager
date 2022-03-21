namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAnonymousLoginResponse")]
public readonly record struct LanConfigSecurityGetAnonymousLoginResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AnonymousLoginEnabled")] bool AnonymousLoginEnabled);
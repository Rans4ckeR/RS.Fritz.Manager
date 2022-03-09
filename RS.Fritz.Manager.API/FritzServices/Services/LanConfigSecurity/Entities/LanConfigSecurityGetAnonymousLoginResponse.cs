namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAnonymousLoginResponse")]
public sealed record LanConfigSecurityGetAnonymousLoginResponse
{
    [MessageBodyMember(Name = "NewX_AVM-DE_AnonymousLoginEnabled")]
    public bool AnonymousLoginEnabled { get; set; }
}
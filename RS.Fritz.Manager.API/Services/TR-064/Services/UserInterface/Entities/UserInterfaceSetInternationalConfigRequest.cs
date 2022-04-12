namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetInternationalConfig")]
public readonly record struct UserInterfaceSetInternationalConfigRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Language")] string Language,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Country")] string Country,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Annex")] string Annex);
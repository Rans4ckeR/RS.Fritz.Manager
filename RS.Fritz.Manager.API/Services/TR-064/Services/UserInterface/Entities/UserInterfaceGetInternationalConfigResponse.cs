namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInternationalConfigResponse")]
public readonly record struct UserInterfaceGetInternationalConfigResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Language")] string Language,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Country")] string Country,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Annex")] string Annex,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_LanguageList")] string LanguageList,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_CountryList")] string CountryList,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AnnexList")] string AnnexList);
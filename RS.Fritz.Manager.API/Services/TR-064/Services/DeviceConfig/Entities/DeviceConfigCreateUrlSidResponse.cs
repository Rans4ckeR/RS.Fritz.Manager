namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "CreateUrlSidResponse")]
public readonly record struct DeviceConfigCreateUrlSidResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UrlSID")] string UrlSid);
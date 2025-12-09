#pragma warning disable CA1054 // URI-like parameters should not be strings
#pragma warning disable CA1056 // URI-like properties should not be strings
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "CreateUrlSidResponse")]
public readonly record struct DeviceConfigCreateUrlSidResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UrlSID")] string UrlSid);
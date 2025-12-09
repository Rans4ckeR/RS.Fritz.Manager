#pragma warning disable CA1054 // URI-like parameters should not be strings
#pragma warning disable CA1056 // URI-like properties should not be strings
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "DoManualUpdate")]
public readonly record struct UserInterfaceDoManualUpdateRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DownloadURL")] string DownloadUrl,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AllowDowngrade")] bool AllowDowngrade);
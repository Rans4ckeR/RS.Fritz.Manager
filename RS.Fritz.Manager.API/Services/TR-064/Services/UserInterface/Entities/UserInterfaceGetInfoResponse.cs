#pragma warning disable CA1054 // URI-like parameters should not be strings
#pragma warning disable CA1056 // URI-like properties should not be strings
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct UserInterfaceGetInfoResponse(
    [property: MessageBodyMember(Name = "NewUpgradeAvailable")] bool UpgradeAvailable,
    [property: MessageBodyMember(Name = "NewPasswordRequired")] bool PasswordRequired,
    [property: MessageBodyMember(Name = "NewPasswordUserSelectable")] bool PasswordUserSelectable,
    [property: MessageBodyMember(Name = "NewWarrantyDate")] DateTime WarrantyDate,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Version")] string Version,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DownloadURL")] string DownloadUrl,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_InfoURL")] string InfoUrl,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UpdateState")] string UpdateState,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_BuildType")] string BuildType,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_SetupAssistantStatus")] bool SetupAssistantStatus);
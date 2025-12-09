#pragma warning disable CA1054 // URI-like parameters should not be strings
#pragma warning disable CA1056 // URI-like properties should not be strings
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "AvmGetInfoResponse")]
public readonly record struct UserInterfaceAvmGetInfoResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AutoUpdateMode")] string AutoUpdateMode,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UpdateTime")] DateTimeOffset UpdateTime,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_LastFwVersion")] string LastFwVersion,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_LastInfoUrl")] string LastInfoUrl,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_CurrentFwVersion")] string CurrentFwVersion,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UpdateSuccessful")] string UpdateSuccessful);
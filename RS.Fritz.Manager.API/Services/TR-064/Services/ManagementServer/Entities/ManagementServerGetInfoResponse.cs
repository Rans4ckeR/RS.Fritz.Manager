#pragma warning disable CA1054 // URI-like parameters should not be strings
#pragma warning disable CA1056 // URI-like properties should not be strings
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct ManagementServerGetInfoResponse(
    [property: MessageBodyMember(Name = "NewURL")] string Url,
    [property: MessageBodyMember(Name = "NewUsername")] string Username,
    [property: MessageBodyMember(Name = "NewPeriodicInformEnable")] bool PeriodicInformEnable,
    [property: MessageBodyMember(Name = "NewPeriodicInformInterval")] ushort PeriodicInformInterval,
    [property: MessageBodyMember(Name = "NewPeriodicInformTime")] DateTime PeriodicInformTime,
    [property: MessageBodyMember(Name = "NewParameterKey")] string ParameterKey,
    [property: MessageBodyMember(Name = "NewParameterHash")] string ParameterHash,
    [property: MessageBodyMember(Name = "NewConnectionRequestURL")] string ConnectionRequestUrl,
    [property: MessageBodyMember(Name = "NewConnectionRequestUsername")] string ConnectionRequestUsername,
    [property: MessageBodyMember(Name = "NewUpgradesManaged")] bool UpgradesManaged);
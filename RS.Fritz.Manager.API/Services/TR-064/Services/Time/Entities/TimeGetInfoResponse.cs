namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct TimeGetInfoResponse(
    [property: MessageBodyMember(Name = "NewNTPServer1")] string NtpServer1,
    [property: MessageBodyMember(Name = "NewNTPServer2")] string NtpServer2,
    [property: MessageBodyMember(Name = "NewCurrentLocalTime")] DateTimeOffset CurrentLocalTime,
    [property: MessageBodyMember(Name = "NewLocalTimeZone")] string LocalTimeZone,
    [property: MessageBodyMember(Name = "NewLocalTimeZoneName")] string LocalTimeZoneName,
    [property: MessageBodyMember(Name = "NewDaylightSavingsUsed")] bool DaylightSavingsUsed,
    [property: MessageBodyMember(Name = "NewDaylightSavingsStart")] DateTime DaylightSavingsStart,
    [property: MessageBodyMember(Name = "NewDaylightSavingsEnd")] DateTime DaylightSavingsEnd);
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetPeriodicInform")]
public readonly record struct ManagementServerSetPeriodicInformRequest(
    [property: MessageBodyMember(Name = "NewPeriodicInformEnable")] bool PeriodicInformEnable,
    [property: MessageBodyMember(Name = "NewPeriodicInformInterval")] ushort PeriodicInformInterval,
    [property: MessageBodyMember(Name = "NewPeriodicInformTime")] DateTime PeriodicInformTime);
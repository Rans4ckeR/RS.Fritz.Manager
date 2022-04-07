namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetPersistentDataResponse")]
public readonly record struct DeviceConfigGetPersistentDataResponse(
    [property: MessageBodyMember(Name = "NewPersistentData")] string PersistentData);
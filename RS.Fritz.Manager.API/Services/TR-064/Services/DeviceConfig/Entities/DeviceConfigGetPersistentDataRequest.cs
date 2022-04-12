namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetPersistentData")]
public readonly record struct DeviceConfigGetPersistentDataRequest;
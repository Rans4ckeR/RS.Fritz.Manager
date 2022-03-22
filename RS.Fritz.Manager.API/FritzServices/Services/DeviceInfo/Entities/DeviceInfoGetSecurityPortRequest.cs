namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetSecurityPort")]
public readonly record struct DeviceInfoGetSecurityPortRequest;
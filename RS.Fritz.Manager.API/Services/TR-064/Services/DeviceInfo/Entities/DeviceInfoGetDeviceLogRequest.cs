namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDeviceLog")]
public readonly record struct DeviceInfoGetDeviceLogRequest;
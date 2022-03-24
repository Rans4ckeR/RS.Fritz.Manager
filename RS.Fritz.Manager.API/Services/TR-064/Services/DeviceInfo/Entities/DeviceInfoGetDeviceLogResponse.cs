namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDeviceLogResponse")]
public readonly record struct DeviceInfoGetDeviceLogResponse(
    [property: MessageBodyMember(Name = "NewDeviceLog")] string DeviceLog);
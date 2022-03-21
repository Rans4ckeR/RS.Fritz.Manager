namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDeviceLogResponse")]
public readonly record struct DeviceInfoGetDeviceLogResponse(
    [property: MessageBodyMember(Name = "NewDeviceLog")] string DeviceLog);
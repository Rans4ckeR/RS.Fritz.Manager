namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDeviceLog")]
public readonly record struct DeviceInfoGetDeviceLogRequest;
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDeviceLog")]
public sealed record DeviceInfoGetDeviceLogRequest;
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetSecurityPort")]
public readonly record struct DeviceInfoGetSecurityPortRequest;
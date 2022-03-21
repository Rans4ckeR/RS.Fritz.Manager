namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetSecurityPortResponse")]
public readonly record struct DeviceInfoGetSecurityPortResponse(
    [property: MessageBodyMember(Name = "NewSecurityPort")] ushort SecurityPort);
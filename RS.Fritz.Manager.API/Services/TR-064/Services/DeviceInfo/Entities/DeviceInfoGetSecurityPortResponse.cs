namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetSecurityPortResponse")]
public readonly record struct DeviceInfoGetSecurityPortResponse(
    [property: MessageBodyMember(Name = "NewSecurityPort")] ushort SecurityPort);
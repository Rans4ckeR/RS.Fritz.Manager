namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetSecurityPortResponse")]
public sealed record DeviceInfoGetSecurityPortResponse
{
    [MessageBodyMember(Name = "NewSecurityPort")]
    public ushort SecurityPort { get; set; }
}
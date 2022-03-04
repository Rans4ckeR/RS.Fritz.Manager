namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetSecurityPort")]
    public sealed record DeviceInfoGetSecurityPortRequest;
}
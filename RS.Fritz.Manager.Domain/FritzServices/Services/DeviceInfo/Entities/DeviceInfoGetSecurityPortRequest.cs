namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetSecurityPort")]
    public sealed record DeviceInfoGetSecurityPortRequest
    {
    }
}
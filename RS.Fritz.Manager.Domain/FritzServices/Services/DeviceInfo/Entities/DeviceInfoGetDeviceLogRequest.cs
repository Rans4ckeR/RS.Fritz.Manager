namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDeviceLog")]
    public sealed record DeviceInfoGetDeviceLogRequest;
}
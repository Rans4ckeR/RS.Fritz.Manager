namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDeviceLogResponse")]
    public sealed record DeviceInfoGetDeviceLogResponse
    {
        [MessageBodyMember(Name = "NewDeviceLog")]
        public string DeviceLog { get; set; }
    }
}
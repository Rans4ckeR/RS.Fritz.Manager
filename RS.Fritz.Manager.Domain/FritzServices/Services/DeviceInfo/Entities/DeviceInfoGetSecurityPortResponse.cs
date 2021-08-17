namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetSecurityPortResponse")]
    public sealed record DeviceInfoGetSecurityPortResponse
    {
        [MessageBodyMember(Name = "NewSecurityPort")]
        public ushort SecurityPort { get; set; }
    }
}
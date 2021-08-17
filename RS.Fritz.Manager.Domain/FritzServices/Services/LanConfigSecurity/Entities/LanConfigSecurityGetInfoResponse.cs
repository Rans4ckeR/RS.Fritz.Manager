namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetInfoResponse")]
    public sealed record LanConfigSecurityGetInfoResponse
    {
        [MessageBodyMember(Name = "NewMaxCharsPassword")]
        public ushort MaxCharsPassword { get; set; }

        [MessageBodyMember(Name = "NewMinCharsPassword")]
        public ushort MinCharsPassword { get; set; }

        [MessageBodyMember(Name = "NewAllowedCharsPassword")]
        public string AllowedCharsPassword { get; set; }
    }
}
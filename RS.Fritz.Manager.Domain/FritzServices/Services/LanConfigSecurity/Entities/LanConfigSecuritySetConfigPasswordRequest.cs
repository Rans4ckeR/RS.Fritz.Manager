namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "SetConfigPassword")]
    public sealed record LanConfigSecuritySetConfigPasswordRequest
    {
        [MessageBodyMember(Name = "NewPassword")]
        public string Password { get; set; }
    }
}
namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "SetConfigPassword")]
    public sealed record LanConfigSecuritySetConfigPasswordRequest
    {
        [MessageBodyMember(Name = "NewPassword")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Password { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
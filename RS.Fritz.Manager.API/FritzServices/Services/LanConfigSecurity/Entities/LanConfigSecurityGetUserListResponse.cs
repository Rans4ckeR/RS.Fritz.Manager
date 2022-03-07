namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetUserListResponse")]
    public sealed record LanConfigSecurityGetUserListResponse
    {
        [MessageBodyMember(Name = "NewX_AVM-DE_UserList")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string UserList { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
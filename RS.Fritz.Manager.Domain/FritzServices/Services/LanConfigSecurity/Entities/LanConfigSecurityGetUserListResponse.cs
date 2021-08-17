namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetUserListResponse")]
    public sealed record LanConfigSecurityGetUserListResponse
    {
        [MessageBodyMember(Name = "NewX_AVM-DE_UserList")]
        public string UserList { get; set; }
    }
}
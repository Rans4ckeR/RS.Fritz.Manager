namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetCurrentUserResponse")]
    public sealed record LanConfigSecurityGetCurrentUserResponse
    {
        [MessageBodyMember(Name = "NewX_AVM-DE_CurrentUsername")]
        public string CurrentUsername { get; set; }

        [MessageBodyMember(Name = "NewX_AVM-DE_CurrentUserRights")]
        public string CurrentUserRights { get; set; }
    }
}
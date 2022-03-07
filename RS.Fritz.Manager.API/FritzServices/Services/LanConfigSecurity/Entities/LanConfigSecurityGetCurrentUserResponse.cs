namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetCurrentUserResponse")]
    public sealed record LanConfigSecurityGetCurrentUserResponse
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [MessageBodyMember(Name = "NewX_AVM-DE_CurrentUsername")]
        public string CurrentUsername { get; set; }

        [MessageBodyMember(Name = "NewX_AVM-DE_CurrentUserRights")]
        public string CurrentUserRights { get; set; }
    }
}
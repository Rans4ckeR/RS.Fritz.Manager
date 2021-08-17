namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetCurrentUser")]
    public sealed record LanConfigSecurityGetCurrentUserRequest
    {
    }
}
namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetCurrentUser")]
    public sealed record LanConfigSecurityGetCurrentUserRequest;
}
namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetUserList")]
    public sealed record LanConfigSecurityGetUserListRequest;
}
namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetAnonymousLogin")]
    public sealed record LanConfigSecurityGetAnonymousLoginRequest;
}
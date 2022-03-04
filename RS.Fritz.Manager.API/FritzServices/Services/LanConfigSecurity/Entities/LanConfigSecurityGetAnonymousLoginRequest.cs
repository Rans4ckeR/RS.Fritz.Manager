namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetAnonymousLogin")]
    public sealed record LanConfigSecurityGetAnonymousLoginRequest;
}
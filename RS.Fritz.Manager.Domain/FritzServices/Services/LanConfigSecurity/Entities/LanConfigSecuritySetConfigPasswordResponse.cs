namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "SetConfigPasswordResponse")]
    public sealed record LanConfigSecuritySetConfigPasswordResponse
    {
    }
}
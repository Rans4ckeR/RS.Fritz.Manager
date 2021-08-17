namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDSLInfo")]
    public sealed record WanDslInterfaceConfigGetDSLInfoRequest
    {
    }
}
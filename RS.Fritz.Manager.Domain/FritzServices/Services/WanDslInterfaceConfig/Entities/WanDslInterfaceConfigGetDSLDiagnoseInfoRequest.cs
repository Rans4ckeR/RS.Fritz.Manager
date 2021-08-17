namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDSLDiagnoseInfo")]
    public sealed record WanDslInterfaceConfigGetDSLDiagnoseInfoRequest
    {
    }
}
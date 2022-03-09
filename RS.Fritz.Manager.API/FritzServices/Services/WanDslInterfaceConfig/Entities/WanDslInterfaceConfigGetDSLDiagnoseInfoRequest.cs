namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDSLDiagnoseInfo")]
    public sealed record WanDslInterfaceConfigGetDSLDiagnoseInfoRequest;
}
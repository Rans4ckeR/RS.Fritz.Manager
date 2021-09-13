namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDSLDiagnoseInfo")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record WanDslInterfaceConfigGetDSLDiagnoseInfoRequest;
#pragma warning restore S101 // Types should be named in PascalCase
}
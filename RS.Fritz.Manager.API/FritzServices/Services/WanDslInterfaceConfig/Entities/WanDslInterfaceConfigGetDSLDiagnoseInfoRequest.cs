namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDslDiagnoseInfo")]
public readonly record struct WanDslInterfaceConfigGetDslDiagnoseInfoRequest;
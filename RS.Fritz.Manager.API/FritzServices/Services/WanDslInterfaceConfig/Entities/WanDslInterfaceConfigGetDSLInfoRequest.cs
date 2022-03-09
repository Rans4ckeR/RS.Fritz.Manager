namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDSLInfo")]
public sealed record WanDslInterfaceConfigGetDSLInfoRequest;
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDslInfo")]
public readonly record struct WanDslInterfaceConfigGetDslInfoRequest;
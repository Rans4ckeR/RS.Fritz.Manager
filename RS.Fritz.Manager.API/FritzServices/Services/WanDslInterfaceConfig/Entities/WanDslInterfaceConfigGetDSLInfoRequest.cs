namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDslInfo")]
public readonly record struct WanDslInterfaceConfigGetDslInfoRequest;
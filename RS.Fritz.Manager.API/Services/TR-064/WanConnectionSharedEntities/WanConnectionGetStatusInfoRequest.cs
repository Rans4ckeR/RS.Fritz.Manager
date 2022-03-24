namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetStatusInfo")]
public readonly record struct WanConnectionGetStatusInfoRequest;
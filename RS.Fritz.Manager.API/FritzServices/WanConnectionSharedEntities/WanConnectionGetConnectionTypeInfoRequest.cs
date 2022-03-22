namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetConnectionTypeInfo")]
public readonly record struct WanConnectionGetConnectionTypeInfoRequest;
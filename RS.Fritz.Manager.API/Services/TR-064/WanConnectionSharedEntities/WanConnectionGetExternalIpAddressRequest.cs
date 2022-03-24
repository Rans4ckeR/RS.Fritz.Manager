namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetExternalIpAddress")]
public readonly record struct WanConnectionGetExternalIpAddressRequest;
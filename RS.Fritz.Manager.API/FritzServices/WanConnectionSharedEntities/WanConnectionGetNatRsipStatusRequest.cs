namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetNatRsipStatus")]
public readonly record struct WanConnectionGetNatRsipStatusRequest;
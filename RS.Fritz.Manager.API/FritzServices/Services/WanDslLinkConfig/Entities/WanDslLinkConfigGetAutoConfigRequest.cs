namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetAutoConfig")]
public readonly record struct WanDslLinkConfigGetAutoConfigRequest;
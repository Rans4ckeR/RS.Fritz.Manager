namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDslLinkInfo")]
public readonly record struct WanDslLinkConfigGetDslLinkInfoRequest;
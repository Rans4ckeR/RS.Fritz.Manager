namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDslLinkInfo")]
public readonly record struct WanDslLinkConfigGetDslLinkInfoRequest;
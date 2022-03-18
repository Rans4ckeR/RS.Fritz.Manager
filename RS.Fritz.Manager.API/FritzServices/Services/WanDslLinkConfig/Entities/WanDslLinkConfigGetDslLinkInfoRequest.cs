namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDslLinkInfo")]
public sealed record WanDslLinkConfigGetDslLinkInfoRequest;
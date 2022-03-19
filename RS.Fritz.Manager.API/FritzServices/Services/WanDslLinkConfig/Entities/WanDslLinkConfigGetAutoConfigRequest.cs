namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAutoConfig")]
public sealed record WanDslLinkConfigGetAutoConfigRequest;
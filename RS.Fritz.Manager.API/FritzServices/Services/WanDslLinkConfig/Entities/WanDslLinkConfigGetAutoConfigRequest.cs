namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAutoConfig")]
public readonly record struct WanDslLinkConfigGetAutoConfigRequest;
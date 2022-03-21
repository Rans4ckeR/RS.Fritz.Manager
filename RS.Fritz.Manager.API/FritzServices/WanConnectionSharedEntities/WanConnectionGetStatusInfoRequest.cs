namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetStatusInfo")]
public readonly record struct WanConnectionGetStatusInfoRequest;
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfo")]
public readonly record struct WanIpConnectionGetInfoRequest;
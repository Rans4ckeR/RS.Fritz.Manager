namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetConnectionTypeInfo")]
public readonly record struct WanIpConnectionGetConnectionTypeInfoRequest;
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetExternalIpAddress")]
public sealed record WanIpConnectionGetExternalIpAddressRequest;
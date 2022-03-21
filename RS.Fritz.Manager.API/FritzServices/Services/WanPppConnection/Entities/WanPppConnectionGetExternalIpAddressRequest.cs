namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetExternalIpAddress")]
public readonly record struct WanPppConnectionGetExternalIpAddressRequest;
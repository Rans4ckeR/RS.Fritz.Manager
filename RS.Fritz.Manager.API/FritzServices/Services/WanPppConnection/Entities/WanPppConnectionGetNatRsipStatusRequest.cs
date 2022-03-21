namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetNatRsipStatus")]
public readonly record struct WanPppConnectionGetNatRsipStatusRequest;
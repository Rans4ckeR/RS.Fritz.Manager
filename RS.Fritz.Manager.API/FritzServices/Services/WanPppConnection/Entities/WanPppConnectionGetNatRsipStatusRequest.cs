namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetNatRsipStatus")]
public sealed record WanPppConnectionGetNatRsipStatusRequest;
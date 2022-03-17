namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetStatusInfo")]
public sealed record WanPppConnectionGetStatusInfoRequest;
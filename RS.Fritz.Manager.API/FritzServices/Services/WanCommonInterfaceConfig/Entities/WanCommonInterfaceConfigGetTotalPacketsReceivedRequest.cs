namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalPacketsReceived")]
public sealed record WanCommonInterfaceConfigGetTotalPacketsReceivedRequest;
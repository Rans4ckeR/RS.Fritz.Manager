namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalPacketsReceived")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsReceivedRequest;
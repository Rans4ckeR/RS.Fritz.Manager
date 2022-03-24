namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTotalPacketsReceived")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsReceivedRequest;
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTotalPacketsSent")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsSentRequest;
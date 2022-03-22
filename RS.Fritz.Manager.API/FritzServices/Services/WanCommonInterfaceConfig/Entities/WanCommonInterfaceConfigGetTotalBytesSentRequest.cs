namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTotalBytesSent")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesSentRequest;
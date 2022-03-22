namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTotalBytesReceived")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesReceivedRequest;
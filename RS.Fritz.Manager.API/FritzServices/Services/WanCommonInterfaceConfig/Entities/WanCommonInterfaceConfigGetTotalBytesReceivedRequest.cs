namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalBytesReceived")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesReceivedRequest;
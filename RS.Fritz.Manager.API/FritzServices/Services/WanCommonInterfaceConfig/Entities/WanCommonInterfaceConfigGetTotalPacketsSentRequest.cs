namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalPacketsSent")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsSentRequest;
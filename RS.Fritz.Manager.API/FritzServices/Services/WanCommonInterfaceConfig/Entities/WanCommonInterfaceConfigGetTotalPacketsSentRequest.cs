namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalPacketsSent")]
public sealed record WanCommonInterfaceConfigGetTotalPacketsSentRequest;
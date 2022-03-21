namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalBytesSent")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesSentRequest;
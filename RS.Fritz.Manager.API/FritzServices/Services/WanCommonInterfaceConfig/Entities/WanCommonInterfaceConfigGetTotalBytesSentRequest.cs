namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalBytesSent")]
public sealed record WanCommonInterfaceConfigGetTotalBytesSentRequest;
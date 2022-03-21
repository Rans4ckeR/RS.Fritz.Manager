namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetStatusInfoResponse")]
public readonly record struct WanConnectionGetStatusInfoResponse(
    [property: MessageBodyMember(Name = "NewConnectionStatus")] string ConnectionStatus,
    [property: MessageBodyMember(Name = "NewLastConnectionError")] string LastConnectionError,
    [property: MessageBodyMember(Name = "NewUptime")] uint Uptime);
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTotalPacketsSentResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsSentResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsSent")] uint TotalPacketsSent);
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTotalBytesSentResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesSentResponse(
    [property: MessageBodyMember(Name = "NewTotalBytesSent")] uint TotalBytesSent);
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTotalBytesReceivedResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesReceivedResponse(
    [property: MessageBodyMember(Name = "NewTotalBytesReceived")] uint TotalBytesReceived);
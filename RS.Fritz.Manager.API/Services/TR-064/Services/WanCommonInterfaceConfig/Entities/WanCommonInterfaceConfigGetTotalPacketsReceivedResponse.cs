namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetTotalPacketsReceivedResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsReceivedResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsReceived")] uint TotalPacketsReceived);
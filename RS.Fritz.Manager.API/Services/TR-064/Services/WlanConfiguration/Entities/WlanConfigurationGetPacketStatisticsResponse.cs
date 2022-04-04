namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetPacketStatisticsResponse")]
public readonly record struct WlanConfigurationGetPacketStatisticsResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsSent")] uint TotalPacketsSent,
    [property: MessageBodyMember(Name = "NewTotalPacketsReceived")] uint TotalPacketsReceived);
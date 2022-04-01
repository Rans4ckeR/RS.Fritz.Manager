namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetStatisticsResponse")]
public readonly record struct WlanConfigurationGetStatisticsResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsSent")] uint TotalPacketsSent,
    [property: MessageBodyMember(Name = "NewTotalPacketsReceived")] uint TotalPacketsReceived);
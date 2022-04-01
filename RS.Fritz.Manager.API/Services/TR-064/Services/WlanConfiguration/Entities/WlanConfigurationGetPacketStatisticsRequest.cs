namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetPacketStatistics")]
public readonly record struct WlanConfigurationGetPacketStatisticsRequest;
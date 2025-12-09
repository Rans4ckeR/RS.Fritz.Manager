namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetStatistics")]
public readonly record struct WanFiberGetStatisticsRequest;
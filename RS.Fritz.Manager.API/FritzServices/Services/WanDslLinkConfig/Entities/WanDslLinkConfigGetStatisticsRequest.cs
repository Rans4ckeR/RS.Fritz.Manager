namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetStatistics")]
public readonly record struct WanDslLinkConfigGetStatisticsRequest;
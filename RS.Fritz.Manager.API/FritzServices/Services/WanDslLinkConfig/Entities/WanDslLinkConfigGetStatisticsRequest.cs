namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetStatistics")]
public sealed record WanDslLinkConfigGetStatisticsRequest;
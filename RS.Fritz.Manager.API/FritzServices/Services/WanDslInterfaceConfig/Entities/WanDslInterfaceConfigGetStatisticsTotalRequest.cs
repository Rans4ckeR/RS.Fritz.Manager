namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetStatisticsTotal")]
public readonly record struct WanDslInterfaceConfigGetStatisticsTotalRequest;
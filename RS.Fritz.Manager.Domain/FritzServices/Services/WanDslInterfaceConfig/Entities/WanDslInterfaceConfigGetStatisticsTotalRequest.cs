namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetStatisticsTotal")]
    public sealed record WanDslInterfaceConfigGetStatisticsTotalRequest
    {
    }
}
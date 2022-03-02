namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetTotalBytesSent")]
    public sealed record WanCommonInterfaceConfigGetTotalBytesSentRequest;
}
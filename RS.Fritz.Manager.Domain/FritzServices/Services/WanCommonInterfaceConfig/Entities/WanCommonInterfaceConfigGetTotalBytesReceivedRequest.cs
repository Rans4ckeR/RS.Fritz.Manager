namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetTotalBytesReceived")]
    public sealed record WanCommonInterfaceConfigGetTotalBytesReceivedRequest;
}
namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetTotalBytesReceived")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record WanCommonInterfaceConfigGetTotalBytesReceivedRequest;
#pragma warning restore S101 // Types should be named in PascalCase
}
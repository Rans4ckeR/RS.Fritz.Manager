namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetTotalBytesSent")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record WanCommonInterfaceConfigGetTotalBytesSentRequest;
#pragma warning restore S101 // Types should be named in PascalCase
}
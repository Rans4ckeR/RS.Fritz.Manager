namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetHostListPath")]
    public sealed record HostsGetHostListPathRequest;
}
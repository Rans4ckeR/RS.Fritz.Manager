namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetHostNumberOfEntries")]
    public sealed record HostsGetHostNumberOfEntriesRequest;
}
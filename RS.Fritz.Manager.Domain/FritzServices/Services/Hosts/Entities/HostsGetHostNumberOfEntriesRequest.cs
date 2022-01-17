namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetHostNumberOfEntries")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record HostsGetHostNumberOfEntriesRequest;
#pragma warning restore S101 // Types should be named in PascalCase
}

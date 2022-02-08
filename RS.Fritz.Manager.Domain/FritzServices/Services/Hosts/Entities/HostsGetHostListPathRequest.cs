namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetHostListPath")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record HostsGetHostListPathRequest;
#pragma warning restore S101 // Types should be named in PascalCase
}
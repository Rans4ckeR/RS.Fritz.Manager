

namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetHostNumberOfEntriesResponse")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record HostsGetHostNumberOfEntriesResponse
#pragma warning restore S101 // Types should be named in PascalCase
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [MessageBodyMember(Name = "NewHostNumberOfEntries")]
        public uint HostNumberOfEntries { get; set; }
    }
}
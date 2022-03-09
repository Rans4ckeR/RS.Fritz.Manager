namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetHostNumberOfEntriesResponse")]
public sealed record HostsGetHostNumberOfEntriesResponse
{
    [MessageBodyMember(Name = "NewHostNumberOfEntries")]
    public uint HostNumberOfEntries { get; set; }
}
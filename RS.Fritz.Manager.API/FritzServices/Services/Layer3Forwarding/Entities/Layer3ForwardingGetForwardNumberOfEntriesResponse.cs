namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetForwardNumberOfEntriesResponse")]
public sealed record Layer3ForwardingGetForwardNumberOfEntriesResponse
{
    [MessageBodyMember(Name = "NewForwardNumberOfEntries")]
    public ushort ForwardNumberOfEntries { get; set; }
}
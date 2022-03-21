namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetForwardNumberOfEntriesResponse")]
public readonly record struct Layer3ForwardingGetForwardNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewForwardNumberOfEntries")] ushort ForwardNumberOfEntries);
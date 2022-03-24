namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetForwardNumberOfEntriesResponse")]
public readonly record struct Layer3ForwardingGetForwardNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewForwardNumberOfEntries")] ushort ForwardNumberOfEntries);
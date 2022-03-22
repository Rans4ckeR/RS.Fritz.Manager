namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetGenericForwardingEntry")]
public readonly record struct Layer3ForwardingGetGenericForwardingEntryRequest(
    [property: MessageBodyMember(Name = "NewForwardingIndex")] ushort ForwardingIndex);
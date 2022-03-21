namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetGenericForwardingEntry")]
public readonly record struct Layer3ForwardingGetGenericForwardingEntryRequest(
    [property: MessageBodyMember(Name = "NewForwardingIndex")] ushort ForwardingIndex);
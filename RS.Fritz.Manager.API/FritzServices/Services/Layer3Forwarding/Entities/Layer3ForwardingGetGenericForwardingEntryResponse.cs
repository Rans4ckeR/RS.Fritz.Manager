namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetGenericForwardingEntryResponse")]
public readonly record struct Layer3ForwardingGetGenericForwardingEntryResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewStatus")] string Status,
    [property: MessageBodyMember(Name = "NewType")] string Type,
    [property: MessageBodyMember(Name = "NewDestIPAddress")] string DestIPAddress,
    [property: MessageBodyMember(Name = "NewDestSubnetMask")] string DestSubnetMask,
    [property: MessageBodyMember(Name = "NewSourceIPAddress")] string SourceIPAddress,
    [property: MessageBodyMember(Name = "NewSourceSubnetMask")] string SourceSubnetMask,
    [property: MessageBodyMember(Name = "NewGatewayIPAddress")] string GatewayIPAddress,
    [property: MessageBodyMember(Name = "NewInterface")] string Interface,
    [property: MessageBodyMember(Name = "NewForwardingMetric")] int ForwardingMetric);
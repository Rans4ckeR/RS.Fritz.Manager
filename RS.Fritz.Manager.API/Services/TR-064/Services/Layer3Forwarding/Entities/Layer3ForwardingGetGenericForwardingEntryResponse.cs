namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetGenericForwardingEntryResponse")]
public readonly record struct Layer3ForwardingGetGenericForwardingEntryResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewStatus")] string Status,
    [property: MessageBodyMember(Name = "NewType")] string Type,
    [property: MessageBodyMember(Name = "NewDestIPAddress")] string DestIpAddress,
    [property: MessageBodyMember(Name = "NewDestSubnetMask")] string DestSubnetMask,
    [property: MessageBodyMember(Name = "NewSourceIPAddress")] string SourceIpAddress,
    [property: MessageBodyMember(Name = "NewSourceSubnetMask")] string SourceSubnetMask,
    [property: MessageBodyMember(Name = "NewGatewayIPAddress")] string GatewayIpAddress,
    [property: MessageBodyMember(Name = "NewInterface")] string Interface,
    [property: MessageBodyMember(Name = "NewForwardingMetric")] int ForwardingMetric);
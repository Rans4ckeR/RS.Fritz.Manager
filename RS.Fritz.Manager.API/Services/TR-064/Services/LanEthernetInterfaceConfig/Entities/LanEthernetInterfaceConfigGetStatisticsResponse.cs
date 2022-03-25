namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetStatisticsResponse")]
public readonly record struct LanEthernetInterfaceConfigGetStatisticsResponse(
    [property: MessageBodyMember(Name = "NewBytesSent")] uint BytesSent,
    [property: MessageBodyMember(Name = "NewBytesReceived")] uint BytesReceived,
    [property: MessageBodyMember(Name = "NewPacketsSent")] uint PacketsSent,
    [property: MessageBodyMember(Name = "NewPacketsReceived")] uint PacketsReceived);
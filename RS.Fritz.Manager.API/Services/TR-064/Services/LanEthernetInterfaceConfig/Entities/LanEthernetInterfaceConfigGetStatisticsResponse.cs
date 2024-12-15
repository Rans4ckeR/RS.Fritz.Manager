namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetStatisticsResponse")]
public readonly record struct LanEthernetInterfaceConfigGetStatisticsResponse(
    [property: MessageBodyMember(Name = "NewBytesSent")] long BytesSent,
    [property: MessageBodyMember(Name = "NewBytesReceived")] long BytesReceived,
    [property: MessageBodyMember(Name = "NewPacketsSent")] long PacketsSent,
    [property: MessageBodyMember(Name = "NewPacketsReceived")] long PacketsReceived);
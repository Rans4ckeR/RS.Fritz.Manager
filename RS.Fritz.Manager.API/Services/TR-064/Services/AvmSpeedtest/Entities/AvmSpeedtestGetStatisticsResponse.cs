namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetStatisticsResponse")]
public readonly record struct AvmSpeedtestGetStatisticsResponse(
    [property: MessageBodyMember(Name = "NewByteCount")] uint ByteCount,
    [property: MessageBodyMember(Name = "NewKbitsCurrent")] uint KilobitsCurrent,
    [property: MessageBodyMember(Name = "NewKbitsAvg")] uint KilobitsAverage,
    [property: MessageBodyMember(Name = "NewPacketCount")] uint PacketCount,
    [property: MessageBodyMember(Name = "NewPPSCurrent")] uint PacketsPerSecondCurrent,
    [property: MessageBodyMember(Name = "NewPPSAvg")] uint PacketsPerSecondAverage);
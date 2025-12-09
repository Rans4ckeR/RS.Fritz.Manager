namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetStatisticsResponse")]
public readonly record struct WanFiberGetStatisticsResponse(
    [property: MessageBodyMember(Name = "NewBytesSent")] uint BytesSent,
    [property: MessageBodyMember(Name = "NewBytesReceived")] uint BytesReceived,
    [property: MessageBodyMember(Name = "NewPacketsSent")] uint PacketsSent,
    [property: MessageBodyMember(Name = "NewPacketsReceived")] uint PacketsReceived,
    [property: MessageBodyMember(Name = "NewPacketErrorsSent")] uint PacketErrorsSent,
    [property: MessageBodyMember(Name = "NewPacketErrorsReceived")] uint PacketErrorsReceived,
    [property: MessageBodyMember(Name = "NewPacketsMulticast")] uint PacketsMulticast,
    [property: MessageBodyMember(Name = "NewConnectionRateDown")] uint ConnectionRateDown,
    [property: MessageBodyMember(Name = "NewConnectionRateUp")] uint ConnectionRateUp,
    [property: MessageBodyMember(Name = "NewBestTrainState")] uint BestTrainState,
    [property: MessageBodyMember(Name = "NewResyncs")] uint Resyncs,
    [property: MessageBodyMember(Name = "NewMinutesInShowtime")] uint MinutesInShowtime);
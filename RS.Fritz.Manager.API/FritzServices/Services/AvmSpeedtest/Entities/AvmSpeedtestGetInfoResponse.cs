namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct AvmSpeedtestGetInfoResponse(
    [property: MessageBodyMember(Name = "NewEnableTcp")] bool EnableTcp,
    [property: MessageBodyMember(Name = "NewEnableUdp")] bool EnableUdp,
    [property: MessageBodyMember(Name = "NewEnableUdpBidirect")] bool EnableUdpBidirect,
    [property: MessageBodyMember(Name = "NewWANEnableTcp")] bool WanEnableTcp,
    [property: MessageBodyMember(Name = "NewWANEnableUdp")] bool WanEnableUdp,
    [property: MessageBodyMember(Name = "NewPortTcp")] uint PortTcp,
    [property: MessageBodyMember(Name = "NewPortUdp")] uint PortUdp,
    [property: MessageBodyMember(Name = "NewPortUdpBidirect")] uint PortUdpBidirect);
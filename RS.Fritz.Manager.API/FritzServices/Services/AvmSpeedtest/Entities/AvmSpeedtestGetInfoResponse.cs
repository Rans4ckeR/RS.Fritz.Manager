namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public sealed record AvmSpeedtestGetInfoResponse
{
    [MessageBodyMember(Name = "NewEnableTcp")]
    public bool EnableTcp { get; set; }

    [MessageBodyMember(Name = "NewEnableUdp")]
    public bool EnableUdp { get; set; }

    [MessageBodyMember(Name = "NewEnableUdpBidirect")]
    public bool EnableUdpBidirect { get; set; }

    [MessageBodyMember(Name = "NewWANEnableTcp")]
    public bool WanEnableTcp { get; set; }

    [MessageBodyMember(Name = "NewWANEnableUdp")]
    public bool WanEnableUdp { get; set; }

    [MessageBodyMember(Name = "NewPortTcp")]
    public uint PortTcp { get; set; }

    [MessageBodyMember(Name = "NewPortUdp")]
    public uint PortUdp { get; set; }

    [MessageBodyMember(Name = "NewPortUdpBidirect")]
    public uint PortUdpBidirect { get; set; }
}
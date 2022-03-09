namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public sealed record WanIpConnectionGetInfoResponse
{
    [MessageBodyMember(Name = "NewEnable")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public bool Enable { get; set; }

    [MessageBodyMember(Name = "NewConnectionStatus")]
    public string ConnectionStatus { get; set; }

    [MessageBodyMember(Name = "NewPossibleConnectionTypes")]
    public string PossibleConnectionTypes { get; set; }

    [MessageBodyMember(Name = "NewConnectionType")]
    public string ConnectionType { get; set; }

    [MessageBodyMember(Name = "NewName")]
    public string Name { get; set; }

    [MessageBodyMember(Name = "NewUptime")]
    public uint Uptime { get; set; }

    [MessageBodyMember(Name = "NewLastConnectionError")]
    public string LastConnectionError { get; set; }

    [MessageBodyMember(Name = "NewRSIPAvailable")]
    public bool RSIPAvailable { get; set; }

    [MessageBodyMember(Name = "NewNATEnabled")]
    public bool NATEnabled { get; set; }

    [MessageBodyMember(Name = "NewExternalIPAddress")]
    public string ExternalIPAddress { get; set; }

    [MessageBodyMember(Name = "NewDNSServers")]
    public string DNSServers { get; set; }

    [MessageBodyMember(Name = "NewMACAddress")]
    public string MACAddress { get; set; }

    [MessageBodyMember(Name = "NewConnectionTrigger")]
    public string ConnectionTrigger { get; set; }

    [MessageBodyMember(Name = "NewRouteProtocolRx")]
    public string RouteProtocolRx { get; set; }

    [MessageBodyMember(Name = "NewDNSEnabled")]
    public bool DNSEnabled { get; set; }

    [MessageBodyMember(Name = "NewDNSOverrideAllowed")]
    public bool DNSOverrideAllowed { get; set; }
}
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct WanIpConnectionGetInfoResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewConnectionStatus")] string ConnectionStatus,
    [property: MessageBodyMember(Name = "NewPossibleConnectionTypes")] string PossibleConnectionTypes,
    [property: MessageBodyMember(Name = "NewConnectionType")] string ConnectionType,
    [property: MessageBodyMember(Name = "NewName")] string Name,
    [property: MessageBodyMember(Name = "NewUptime")] uint Uptime,
    [property: MessageBodyMember(Name = "NewLastConnectionError")] string LastConnectionError,
    [property: MessageBodyMember(Name = "NewRSIPAvailable")] bool RSIPAvailable,
    [property: MessageBodyMember(Name = "NewNATEnabled")] bool NATEnabled,
    [property: MessageBodyMember(Name = "NewExternalIPAddress")] string ExternalIPAddress,
    [property: MessageBodyMember(Name = "NewDNSServers")] string DNSServers,
    [property: MessageBodyMember(Name = "NewMACAddress")] string MACAddress,
    [property: MessageBodyMember(Name = "NewConnectionTrigger")] string ConnectionTrigger,
    [property: MessageBodyMember(Name = "NewRouteProtocolRx")] string RouteProtocolRx,
    [property: MessageBodyMember(Name = "NewDNSEnabled")] bool DNSEnabled,
    [property: MessageBodyMember(Name = "NewDNSOverrideAllowed")] bool DNSOverrideAllowed);
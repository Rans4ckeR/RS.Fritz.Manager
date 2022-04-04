namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct WanIpConnectionGetInfoResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewConnectionStatus")] string ConnectionStatus,
    [property: MessageBodyMember(Name = "NewPossibleConnectionTypes")] string PossibleConnectionTypes,
    [property: MessageBodyMember(Name = "NewConnectionType")] string ConnectionType,
    [property: MessageBodyMember(Name = "NewName")] string Name,
    [property: MessageBodyMember(Name = "NewUptime")] uint Uptime,
    [property: MessageBodyMember(Name = "NewLastConnectionError")] string LastConnectionError,
    [property: MessageBodyMember(Name = "NewRSIPAvailable")] bool RsipAvailable,
    [property: MessageBodyMember(Name = "NewNATEnabled")] bool NatEnabled,
    [property: MessageBodyMember(Name = "NewExternalIPAddress")] string ExternalIpAddress,
    [property: MessageBodyMember(Name = "NewDNSServers")] string DnsServers,
    [property: MessageBodyMember(Name = "NewMACAddress")] string MacAddress,
    [property: MessageBodyMember(Name = "NewConnectionTrigger")] string ConnectionTrigger,
    [property: MessageBodyMember(Name = "NewRouteProtocolRx")] string RouteProtocolRx,
    [property: MessageBodyMember(Name = "NewDNSEnabled")] bool DnsEnabled,
    [property: MessageBodyMember(Name = "NewDNSOverrideAllowed")] bool DnsOverrideAllowed);
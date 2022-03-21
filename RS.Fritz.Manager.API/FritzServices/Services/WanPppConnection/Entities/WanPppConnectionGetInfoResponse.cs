﻿namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct WanPppConnectionGetInfoResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewConnectionStatus")] string ConnectionStatus,
    [property: MessageBodyMember(Name = "NewPossibleConnectionTypes")] string PossibleConnectionTypes,
    [property: MessageBodyMember(Name = "NewConnectionType")] string ConnectionType,
    [property: MessageBodyMember(Name = "NewName")] string Name,
    [property: MessageBodyMember(Name = "NewUptime")] uint Uptime,
    [property: MessageBodyMember(Name = "NewUpstreamMaxBitRate")] uint UpstreamMaxBitRate,
    [property: MessageBodyMember(Name = "NewDownstreamMaxBitRate")] uint DownstreamMaxBitRate,
    [property: MessageBodyMember(Name = "NewLastConnectionError")] string LastConnectionError,
    [property: MessageBodyMember(Name = "NewIdleDisconnectTime")] uint IdleDisconnectTime,
    [property: MessageBodyMember(Name = "NewRSIPAvailable")] bool RSIPAvailable,
    [property: MessageBodyMember(Name = "NewUserName")] string UserName,
    [property: MessageBodyMember(Name = "NewNATEnabled")] bool NATEnabled,
    [property: MessageBodyMember(Name = "NewExternalIPAddress")] string ExternalIPAddress,
    [property: MessageBodyMember(Name = "NewDNSServers")] string DNSServers,
    [property: MessageBodyMember(Name = "NewMACAddress")] string MACAddress,
    [property: MessageBodyMember(Name = "NewConnectionTrigger")] string ConnectionTrigger,
    [property: MessageBodyMember(Name = "NewLastAuthErrorInfo")] string LastAuthErrorInfo,
    [property: MessageBodyMember(Name = "NewMaxCharsUsername")] string MaxCharsUsername,
    [property: MessageBodyMember(Name = "NewMinCharsUsername")] string MinCharsUsername,
    [property: MessageBodyMember(Name = "NewAllowedCharsUsername")] string AllowedCharsUsername,
    [property: MessageBodyMember(Name = "NewMaxCharsPassword")] string MaxCharsPassword,
    [property: MessageBodyMember(Name = "NewMinCharsPassword")] string MinCharsPassword,
    [property: MessageBodyMember(Name = "NewAllowedCharsPassword")] string AllowedCharsPassword,
    [property: MessageBodyMember(Name = "NewTransportType")] string TransportType,
    [property: MessageBodyMember(Name = "NewRouteProtocolRx")] string RouteProtocolRx,
    [property: MessageBodyMember(Name = "NewPPPoEServiceName")] string PPPoEServiceName,
    [property: MessageBodyMember(Name = "NewRemoteIPAddress")] string RemoteIPAddress,
    [property: MessageBodyMember(Name = "NewPPPoEACName")] string PPPoEACName,
    [property: MessageBodyMember(Name = "NewDNSEnabled")] bool DNSEnabled,
    [property: MessageBodyMember(Name = "NewDNSOverrideAllowed")] bool DNSOverrideAllowed);
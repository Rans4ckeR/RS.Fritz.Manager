namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetInfoResponse")]
    public sealed record WanPppConnectionGetInfoResponse
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

        [MessageBodyMember(Name = "NewUpstreamMaxBitRate")]
        public uint UpstreamMaxBitRate { get; set; }

        [MessageBodyMember(Name = "NewDownstreamMaxBitRate")]
        public uint DownstreamMaxBitRate { get; set; }

        [MessageBodyMember(Name = "NewLastConnectionError")]
        public string LastConnectionError { get; set; }

        [MessageBodyMember(Name = "NewIdleDisconnectTime")]
        public uint IdleDisconnectTime { get; set; }

        [MessageBodyMember(Name = "NewRSIPAvailable")]
        public bool RSIPAvailable { get; set; }

        [MessageBodyMember(Name = "NewUserName")]
        public string UserName { get; set; }

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

        [MessageBodyMember(Name = "NewLastAuthErrorInfo")]
        public string LastAuthErrorInfo { get; set; }

        [MessageBodyMember(Name = "NewMaxCharsUsername")]
        public ushort MaxCharsUsername { get; set; }

        [MessageBodyMember(Name = "NewMinCharsUsername")]
        public ushort MinCharsUsername { get; set; }

        [MessageBodyMember(Name = "NewAllowedCharsUsername")]
        public string AllowedCharsUsername { get; set; }

        [MessageBodyMember(Name = "NewMaxCharsPassword")]
        public ushort MaxCharsPassword { get; set; }

        [MessageBodyMember(Name = "NewMinCharsPassword")]
        public ushort MinCharsPassword { get; set; }

        [MessageBodyMember(Name = "NewAllowedCharsPassword")]
        public string AllowedCharsPassword { get; set; }

        [MessageBodyMember(Name = "NewTransportType")]
        public string TransportType { get; set; }

        [MessageBodyMember(Name = "NewRouteProtocolRx")]
        public string RouteProtocolRx { get; set; }

        [MessageBodyMember(Name = "NewPPPoEServiceName")]
        public string PPPoEServiceName { get; set; }

        [MessageBodyMember(Name = "NewRemoteIPAddress")]
        public string RemoteIPAddress { get; set; }

        [MessageBodyMember(Name = "NewPPPoEACName")]
        public string PPPoEACName { get; set; }

        [MessageBodyMember(Name = "NewDNSEnabled")]
        public bool DNSEnabled { get; set; }

        [MessageBodyMember(Name = "NewDNSOverrideAllowed")]
        public bool DNSOverrideAllowed { get; set; }
    }
}
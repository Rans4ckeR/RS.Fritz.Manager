namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct LanHostConfigManagementGetInfoResponse(
    [property: MessageBodyMember(Name = "NewDHCPServerConfigurable")] bool DhcpServerConfigurable,
    [property: MessageBodyMember(Name = "NewDHCPRelay")] bool DhcpRelay,
    [property: MessageBodyMember(Name = "NewMinAddress")] string MinAddress,
    [property: MessageBodyMember(Name = "NewMaxAddress")] string NaxAddress,
    [property: MessageBodyMember(Name = "NewReservedAddresses")] string ReservedAddresses,
    [property: MessageBodyMember(Name = "NewDHCPServerEnable")] bool DhcpServerEnable,
    [property: MessageBodyMember(Name = "NewDNSServers")] string DnsServers,
    [property: MessageBodyMember(Name = "NewDomainName")] string DomainName,
    [property: MessageBodyMember(Name = "NewIPRouters")] string IpRouters,
    [property: MessageBodyMember(Name = "NewSubnetMask")] string SubnetMask);
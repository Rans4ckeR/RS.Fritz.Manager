namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDnsServersResponse")]
public readonly record struct LanHostConfigManagementGetDnsServersResponse(
    [property: MessageBodyMember(Name = "NewDNSServers")] string DnsServers);
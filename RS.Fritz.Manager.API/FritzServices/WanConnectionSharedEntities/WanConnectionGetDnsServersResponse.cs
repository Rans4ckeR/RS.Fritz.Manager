namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDnsServersResponse")]
public readonly record struct WanConnectionGetDnsServersResponse(
    [property: MessageBodyMember(Name = "NewDNSServers")] string DnsServers);
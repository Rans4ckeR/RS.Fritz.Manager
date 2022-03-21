namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDnsServersResponse")]
public readonly record struct WanConnectionGetDnsServersResponse(
    [property: MessageBodyMember(Name = "NewDNSServers")] string DnsServers);
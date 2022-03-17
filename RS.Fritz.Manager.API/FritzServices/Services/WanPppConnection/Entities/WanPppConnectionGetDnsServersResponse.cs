namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDnsServersResponse")]
public sealed record WanPppConnectionGetDnsServersResponse
{
    [MessageBodyMember(Name = "NewDNSServers")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string DnsServers { get; set; }
}
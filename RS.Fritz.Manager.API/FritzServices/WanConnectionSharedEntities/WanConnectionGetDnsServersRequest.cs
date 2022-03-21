namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDnsServers")]
public readonly record struct WanConnectionGetDnsServersRequest;
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDnsServers")]
public readonly record struct LanHostConfigManagementGetDnsServersRequest;
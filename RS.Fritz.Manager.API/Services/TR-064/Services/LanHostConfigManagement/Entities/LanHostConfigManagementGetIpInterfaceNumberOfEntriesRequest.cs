namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetIpInterfaceNumberOfEntries")]
public readonly record struct LanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest;
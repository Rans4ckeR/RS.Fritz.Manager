namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetIpInterfaceNumberOfEntriesResponse")]
public readonly record struct LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse(
    [property: MessageBodyMember(Name = "NewIPInterfaceNumberOfEntries")] ushort IpInterfaceNumberOfEntries);
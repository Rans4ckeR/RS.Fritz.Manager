namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetGenericHostEntryResponse")]
public readonly record struct HostsGetGenericHostEntryResponse(
    [property: MessageBodyMember(Name = "NewIPAddress")] string IpAddress,
    [property: MessageBodyMember(Name = "NewMACAddress")] string MacAddress,
    [property: MessageBodyMember(Name = "NewAddressSource")] string AddressSource,
    [property: MessageBodyMember(Name = "NewLeaseTimeRemaining")] int LeaseTimeRemaining,
    [property: MessageBodyMember(Name = "NewInterfaceType")] string InterfaceType,
    [property: MessageBodyMember(Name = "NewActive")] bool Active,
    [property: MessageBodyMember(Name = "NewHostName")] string HostName);
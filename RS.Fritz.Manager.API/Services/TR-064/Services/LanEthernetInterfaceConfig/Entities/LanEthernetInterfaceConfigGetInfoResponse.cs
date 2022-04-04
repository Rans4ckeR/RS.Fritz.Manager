namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct LanEthernetInterfaceConfigGetInfoResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewStatus")] string Status,
    [property: MessageBodyMember(Name = "NewMACAddress")] string MacAddress,
    [property: MessageBodyMember(Name = "NewMaxBitRate")] string MaxBitRate,
    [property: MessageBodyMember(Name = "NewDuplexMode")] string DuplexMode);
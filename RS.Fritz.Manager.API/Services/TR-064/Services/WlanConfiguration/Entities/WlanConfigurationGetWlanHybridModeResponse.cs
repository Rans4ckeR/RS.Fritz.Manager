namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetWlanHybridModeResponse")]
public readonly record struct WlanConfigurationGetWlanHybridModeResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewBeaconType")] string BeaconType,
    [property: MessageBodyMember(Name = "NewKeyPassphrase")] string KeyPassphrase,
    [property: MessageBodyMember(Name = "NewSSID")] string SsId,
    [property: MessageBodyMember(Name = "NewBSSID")] string BssId,
    [property: MessageBodyMember(Name = "NewTrafficMode")] string TrafficMode,
    [property: MessageBodyMember(Name = "NewManualSpeed")] bool ManualSpeed,
    [property: MessageBodyMember(Name = "NewMaxSpeedDS")] uint MaxSpeedDs,
    [property: MessageBodyMember(Name = "NewMaxSpeedUS")] uint MaxSpeedUs);
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetWlanConnectionInfoResponse")]
public readonly record struct WlanConfigurationGetWlanConnectionInfoResponse(
    [property: MessageBodyMember(Name = "NewAssociatedDeviceMACAddress")] string AssociatedDeviceMacAddress,
    [property: MessageBodyMember(Name = "NewSSID")] string SsId,
    [property: MessageBodyMember(Name = "NewBSSID")] string BssId,
    [property: MessageBodyMember(Name = "NewBeaconType")] string BeaconType,
    [property: MessageBodyMember(Name = "NewChannel")] byte Channel,
    [property: MessageBodyMember(Name = "NewStandard")] string Standard,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AutoChannelEnabled")] bool AutoChannelEnabled,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_ChannelWidth")] ushort ChannelWidth,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_FrequencyBand")] string FrequencyBand,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_SignalStrength")] byte SignalStrength,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Speed")] ushort Speed,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_SpeedRX")] uint SpeedRx,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_SpeedMax")] uint SpeedMax,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_SpeedRXMax")] uint SpeedRxMax);
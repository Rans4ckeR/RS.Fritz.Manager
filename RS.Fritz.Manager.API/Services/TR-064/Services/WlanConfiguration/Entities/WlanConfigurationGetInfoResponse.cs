namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct WlanConfigurationGetInfoResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewStatus")] string Status,
    [property: MessageBodyMember(Name = "NewMaxBitRate")] string MaxBitRate,
    [property: MessageBodyMember(Name = "NewChannel")] byte Channel,
    [property: MessageBodyMember(Name = "NewSSID")] string Ssid,
    [property: MessageBodyMember(Name = "NewBeaconType")] string BeaconType,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_PossibleBeaconTypes")] string PossibleBeaconTypes,
    [property: MessageBodyMember(Name = "NewMACAddressControlEnabled")] bool MacAddressControlEnabled,
    [property: MessageBodyMember(Name = "NewStandard")] string Standard,
    [property: MessageBodyMember(Name = "NewBSSID")] string Bssid,
    [property: MessageBodyMember(Name = "NewBasicEncryptionModes")] string BasicEncryptionModes,
    [property: MessageBodyMember(Name = "NewBasicAuthenticationMode")] string BasicAuthenticationMode,
    [property: MessageBodyMember(Name = "NewMaxCharsSSID")] byte MaxCharsSsid,
    [property: MessageBodyMember(Name = "NewMinCharsSSID")] byte MinCharsSsid,
    [property: MessageBodyMember(Name = "NewAllowedCharsSSID")] string AllowedCharsSsid,
    [property: MessageBodyMember(Name = "NewMinCharsPSK")] byte MinCharsPsk,
    [property: MessageBodyMember(Name = "NewMaxCharsPSK")] byte MaxCharsPsk,
    [property: MessageBodyMember(Name = "NewAllowedCharsPSK")] string AllowedCharsPsk);
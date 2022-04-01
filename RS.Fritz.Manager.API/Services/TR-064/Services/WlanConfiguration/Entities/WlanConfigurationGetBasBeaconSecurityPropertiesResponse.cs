namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetBasBeaconSecurityPropertiesResponse")]
public readonly record struct WlanConfigurationGetBasBeaconSecurityPropertiesResponse(
    [property: MessageBodyMember(Name = "NewBasicEncryptionModes")] string BasicEncryptionModes,
    [property: MessageBodyMember(Name = "NewBasicAuthenticationMode")] string BasicAuthenticationMode);
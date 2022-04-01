namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetBasBeaconSecurityProperties")]
public readonly record struct WlanConfigurationGetBasBeaconSecurityPropertiesRequest;
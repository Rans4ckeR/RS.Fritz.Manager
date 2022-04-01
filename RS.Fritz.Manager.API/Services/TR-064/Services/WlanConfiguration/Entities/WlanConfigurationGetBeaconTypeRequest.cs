namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetBeaconType")]
public readonly record struct WlanConfigurationGetBeaconTypeRequest;
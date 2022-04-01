namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetBeaconAdvertisement")]
public readonly record struct WlanConfigurationGetBeaconAdvertisementRequest;
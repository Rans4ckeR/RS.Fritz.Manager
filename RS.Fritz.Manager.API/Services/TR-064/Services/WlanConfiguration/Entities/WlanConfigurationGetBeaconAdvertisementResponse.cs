namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetBeaconAdvertisementResponse")]
public readonly record struct WlanConfigurationGetBeaconAdvertisementResponse(
    [property: MessageBodyMember(Name = "NewBeaconAdvertisementEnabled")] bool BeaconAdvertisementEnabled);
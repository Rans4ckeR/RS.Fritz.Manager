namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetBeaconTypeResponse")]
public readonly record struct WlanConfigurationGetBeaconTypeResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_PossibleBeaconTypes")] string PossibleBeaconTypes);
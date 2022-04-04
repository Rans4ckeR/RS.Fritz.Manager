namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetNightControlResponse")]
public readonly record struct WlanConfigurationGetNightControlResponse(
    [property: MessageBodyMember(Name = "NewNightControl")] string NightControl,
    [property: MessageBodyMember(Name = "NewNightTimeControlNoForcedOff")] bool NightTimeControlNoForcedOff);
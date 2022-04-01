namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetWpsInfoResponse")]
public readonly record struct WlanConfigurationGetWpsInfoResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_WPSMode")] string WpsMode,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_WPSStatus")] string WpsStatus);
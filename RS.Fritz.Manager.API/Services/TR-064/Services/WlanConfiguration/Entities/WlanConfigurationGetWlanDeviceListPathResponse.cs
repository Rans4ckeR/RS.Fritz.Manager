namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetWlanDeviceListPathResponse")]
public readonly record struct WlanConfigurationGetWlanDeviceListPathResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_WLANDeviceListPath")] string WlanDeviceListPath);
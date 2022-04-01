namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetBssIdResponse")]
public readonly record struct WlanConfigurationGetBssIdResponse(
    [property: MessageBodyMember(Name = "NewBSSID")] string BssId);
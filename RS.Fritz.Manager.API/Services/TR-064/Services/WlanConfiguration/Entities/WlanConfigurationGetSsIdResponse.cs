namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetSsIdResponse")]
public readonly record struct WlanConfigurationGetSsIdResponse(
    [property: MessageBodyMember(Name = "NewSSID")] string SsId);
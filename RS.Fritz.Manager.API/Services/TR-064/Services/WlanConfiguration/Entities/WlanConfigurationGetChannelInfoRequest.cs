namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetChannelInfo")]
public readonly record struct WlanConfigurationGetChannelInfoRequest;
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetWlanExtInfo")]
public readonly record struct WlanConfigurationGetWlanExtInfoRequest;
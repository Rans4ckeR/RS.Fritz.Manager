namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetWpsInfo")]
public readonly record struct WlanConfigurationGetWpsInfoRequest;
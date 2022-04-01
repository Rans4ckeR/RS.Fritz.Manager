namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetWlanConnectionInfo")]
public readonly record struct WlanConfigurationGetWlanConnectionInfoRequest;
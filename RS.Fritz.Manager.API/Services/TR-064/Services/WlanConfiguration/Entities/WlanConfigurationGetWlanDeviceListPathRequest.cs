namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetWlanDeviceListPath")]
public readonly record struct WlanConfigurationGetWlanDeviceListPathRequest;
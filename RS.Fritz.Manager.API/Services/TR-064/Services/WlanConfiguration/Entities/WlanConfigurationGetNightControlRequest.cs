namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetNightControl")]
public readonly record struct WlanConfigurationGetNightControlRequest;
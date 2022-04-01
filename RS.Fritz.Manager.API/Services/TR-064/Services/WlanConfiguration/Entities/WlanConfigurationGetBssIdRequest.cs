namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetBssId")]
public readonly record struct WlanConfigurationGetBssIdRequest;
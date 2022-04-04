namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetSsId")]
public readonly record struct WlanConfigurationGetSsIdRequest;
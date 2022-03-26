namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetAddressRange")]
public readonly record struct LanHostConfigManagementGetAddressRangeRequest;
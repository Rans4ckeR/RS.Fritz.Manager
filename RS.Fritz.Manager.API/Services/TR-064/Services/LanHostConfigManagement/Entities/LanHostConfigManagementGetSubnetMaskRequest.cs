namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetSubnetMask")]
public readonly record struct LanHostConfigManagementGetSubnetMaskRequest;
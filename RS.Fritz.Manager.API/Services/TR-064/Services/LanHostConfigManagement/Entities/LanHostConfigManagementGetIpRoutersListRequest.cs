namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetIpRoutersList")]
public readonly record struct LanHostConfigManagementGetIpRoutersListRequest;
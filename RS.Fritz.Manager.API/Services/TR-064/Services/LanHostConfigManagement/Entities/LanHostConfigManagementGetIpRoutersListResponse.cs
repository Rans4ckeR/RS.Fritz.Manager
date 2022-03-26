namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetIpRoutersListResponse")]
public readonly record struct LanHostConfigManagementGetIpRoutersListResponse(
    [property: MessageBodyMember(Name = "NewIPRouters")] string IpRouters);
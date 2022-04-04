namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetSubnetMaskResponse")]
public readonly record struct LanHostConfigManagementGetSubnetMaskResponse(
    [property: MessageBodyMember(Name = "NewSubnetMask")] string SubnetMask);
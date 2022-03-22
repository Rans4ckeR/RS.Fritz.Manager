namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetProvisioningCode")]
public readonly record struct DeviceInfoSetProvisioningCodeRequest(
    [property: MessageBodyMember(Name = "NewProvisioningCode")] string ProvisioningCode);
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "SetProvisioningCode")]
public readonly record struct DeviceInfoSetProvisioningCodeRequest(
    [property: MessageBodyMember(Name = "NewProvisioningCode")] string ProvisioningCode);
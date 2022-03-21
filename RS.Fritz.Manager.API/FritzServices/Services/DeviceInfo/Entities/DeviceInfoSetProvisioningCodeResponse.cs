namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "SetProvisioningCodeResponse")]
public readonly record struct DeviceInfoSetProvisioningCodeResponse;
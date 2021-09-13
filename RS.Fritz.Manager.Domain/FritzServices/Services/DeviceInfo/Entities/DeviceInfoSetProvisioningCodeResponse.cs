namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "SetProvisioningCodeResponse")]
    public sealed record DeviceInfoSetProvisioningCodeResponse;
}
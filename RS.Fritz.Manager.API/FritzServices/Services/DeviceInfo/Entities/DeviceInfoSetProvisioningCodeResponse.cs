namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "SetProvisioningCodeResponse")]
    public sealed record DeviceInfoSetProvisioningCodeResponse;
}
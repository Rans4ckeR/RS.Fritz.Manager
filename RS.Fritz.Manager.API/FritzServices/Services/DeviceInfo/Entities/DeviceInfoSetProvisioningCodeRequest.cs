﻿namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "SetProvisioningCode")]
    public sealed record DeviceInfoSetProvisioningCodeRequest
    {
        [MessageBodyMember(Name = "NewProvisioningCode")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string ProvisioningCode { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
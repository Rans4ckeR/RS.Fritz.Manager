namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetNatRsipStatusResponse")]
public sealed record WanPppConnectionGetNatRsipStatusResponse
{
    [MessageBodyMember(Name = "NewRSIPAvailable")]
    public bool RsipAvailable { get; set; }

    [MessageBodyMember(Name = "NewNATEnabled")]
    public bool NatEnabled { get; set; }
}
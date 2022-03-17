namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetNatRsipStatusResponse")]
public sealed record WanIpConnectionGetNatRsipStatusResponse
{
    [MessageBodyMember(Name = "NewRSIPAvailable")]
    public bool RsipAvailable { get; set; }

    [MessageBodyMember(Name = "NewNATEnabled")]
    public bool NatEnabled { get; set; }
}
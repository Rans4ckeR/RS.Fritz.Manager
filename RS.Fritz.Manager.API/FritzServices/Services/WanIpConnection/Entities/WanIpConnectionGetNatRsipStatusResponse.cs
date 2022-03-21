namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetNatRsipStatusResponse")]
public readonly record struct WanIpConnectionGetNatRsipStatusResponse(
    [property: MessageBodyMember(Name = "NewRSIPAvailable")] bool RsipAvailable,
    [property: MessageBodyMember(Name = "NewNATEnabled")] bool NatEnabled);
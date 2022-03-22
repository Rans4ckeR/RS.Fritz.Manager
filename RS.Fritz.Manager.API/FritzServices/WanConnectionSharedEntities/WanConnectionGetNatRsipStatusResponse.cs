namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetNatRsipStatusResponse")]
public readonly record struct WanConnectionGetNatRsipStatusResponse(
    [property: MessageBodyMember(Name = "NewRSIPAvailable")] bool RsipAvailable,
    [property: MessageBodyMember(Name = "NewNATEnabled")] bool NatEnabled);
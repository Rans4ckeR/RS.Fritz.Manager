namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetIpTvOptimizedResponse")]
public readonly record struct WlanConfigurationGetIpTvOptimizedResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_IPTVoptimize")] bool IpTvOptimize);
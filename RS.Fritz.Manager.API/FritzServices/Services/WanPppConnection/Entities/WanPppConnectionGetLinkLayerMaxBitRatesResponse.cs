namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetLinkLayerMaxBitRatesResponse")]
public readonly record struct WanPppConnectionGetLinkLayerMaxBitRatesResponse(
    [property: MessageBodyMember(Name = "NewUpstreamMaxBitRate")] uint UpstreamMaxBitRate,
    [property: MessageBodyMember(Name = "NewDownstreamMaxBitRate")] uint DownstreamMaxBitRate);
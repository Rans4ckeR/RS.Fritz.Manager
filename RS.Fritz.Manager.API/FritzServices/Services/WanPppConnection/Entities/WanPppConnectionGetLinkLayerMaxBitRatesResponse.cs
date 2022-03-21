namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetLinkLayerMaxBitRatesResponse")]
public readonly record struct WanPppConnectionGetLinkLayerMaxBitRatesResponse(
    [property: MessageBodyMember(Name = "NewUpstreamMaxBitRate")] uint UpstreamMaxBitRate,
    [property: MessageBodyMember(Name = "NewDownstreamMaxBitRate")] uint DownstreamMaxBitRate);
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetLinkLayerMaxBitRatesResponse")]
public sealed record WanPppConnectionGetLinkLayerMaxBitRatesResponse
{
    [MessageBodyMember(Name = "NewUpstreamMaxBitRate")]
    public uint UpstreamMaxBitRate { get; set; }

    [MessageBodyMember(Name = "NewDownstreamMaxBitRate")]
    public uint DownstreamMaxBitRate { get; set; }
}
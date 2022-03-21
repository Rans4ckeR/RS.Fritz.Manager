namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetCommonLinkPropertiesResponse")]

public readonly record struct WanCommonInterfaceConfigGetCommonLinkPropertiesResponse(
    [property: MessageBodyMember(Name = "NewWANAccessType")] string WanAccessType,
    [property: MessageBodyMember(Name = "NewLayer1UpstreamMaxBitRate")] uint Layer1UpstreamMaxBitRate,
    [property: MessageBodyMember(Name = "NewLayer1DownstreamMaxBitRate")] uint Layer1DownstreamMaxBitRate,
    [property: MessageBodyMember(Name = "NewPhysicalLinkStatus")] string PhysicalLinkStatus);
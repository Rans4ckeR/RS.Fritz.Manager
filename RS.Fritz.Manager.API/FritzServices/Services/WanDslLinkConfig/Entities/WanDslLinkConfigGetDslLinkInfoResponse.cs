namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDslLinkInfoResponse")]
public readonly record struct WanDslLinkConfigGetDslLinkInfoResponse(
    [property: MessageBodyMember(Name = "NewLinkType")] string LinkType,
    [property: MessageBodyMember(Name = "NewLinkStatus")] string LinkStatus);
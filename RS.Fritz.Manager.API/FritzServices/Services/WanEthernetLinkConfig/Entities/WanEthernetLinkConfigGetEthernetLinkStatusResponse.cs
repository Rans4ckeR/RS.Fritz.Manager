namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetEthernetLinkStatusResponse")]
public readonly record struct WanEthernetLinkConfigGetEthernetLinkStatusResponse(
    [property: MessageBodyMember(Name = "NewEthernetLinkStatus")] string EthernetLinkStatus);
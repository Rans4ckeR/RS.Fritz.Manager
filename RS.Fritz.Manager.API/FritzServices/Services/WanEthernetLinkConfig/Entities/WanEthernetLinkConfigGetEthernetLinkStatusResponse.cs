namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetEthernetLinkStatusResponse")]
public readonly record struct WanEthernetLinkConfigGetEthernetLinkStatusResponse(
    [property: MessageBodyMember(Name = "NewEthernetLinkStatus")] string EthernetLinkStatus);
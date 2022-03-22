namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetEthernetLinkStatus")]
public readonly record struct WanEthernetLinkConfigGetEthernetLinkStatusRequest;
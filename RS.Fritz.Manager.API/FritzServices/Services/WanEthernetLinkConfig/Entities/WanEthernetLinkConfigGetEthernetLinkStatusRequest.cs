namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetEthernetLinkStatus")]
public readonly record struct WanEthernetLinkConfigGetEthernetLinkStatusRequest;
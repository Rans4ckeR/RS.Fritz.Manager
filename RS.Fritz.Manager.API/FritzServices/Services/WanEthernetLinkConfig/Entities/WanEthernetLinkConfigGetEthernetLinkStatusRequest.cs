namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetEthernetLinkStatus")]
public sealed record WanEthernetLinkConfigGetEthernetLinkStatusRequest;
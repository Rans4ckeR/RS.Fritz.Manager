namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetEthernetLinkStatusResponse")]
public sealed record WanEthernetLinkConfigGetEthernetLinkStatusResponse
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessageBodyMember(Name = "NewEthernetLinkStatus")]
    public string EthernetLinkStatus { get; set; }
}
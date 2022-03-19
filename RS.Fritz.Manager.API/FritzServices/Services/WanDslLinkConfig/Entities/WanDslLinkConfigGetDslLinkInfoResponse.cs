namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDslLinkInfoResponse")]
public sealed record WanDslLinkConfigGetDslLinkInfoResponse
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessageBodyMember(Name = "NewLinkType")]
    public string LinkType { get; set; }

    [MessageBodyMember(Name = "NewLinkStatus")]
    public string LinkStatus { get; set; }
}
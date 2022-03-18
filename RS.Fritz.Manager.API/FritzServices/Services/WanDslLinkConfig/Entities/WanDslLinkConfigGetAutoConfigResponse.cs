namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAutoConfigResponse")]
public sealed record WanDslLinkConfigGetAutoConfigResponse
{
    [MessageBodyMember(Name = "NewAutoConfig")]
    public bool AutoConfig { get; set; }
}
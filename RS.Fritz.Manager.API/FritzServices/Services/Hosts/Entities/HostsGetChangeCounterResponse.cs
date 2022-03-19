namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetChangeCounterResponse")]
public sealed record HostsGetChangeCounterResponse
{
    [MessageBodyMember(Name = "NewX_AVM-DE_ChangeCounter")]
    public uint ChangeCounter { get; set; }
}
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetChangeCounterResponse")]
public readonly record struct HostsGetChangeCounterResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_ChangeCounter")] uint ChangeCounter);
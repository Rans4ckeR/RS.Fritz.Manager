namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetFriendlyNameResponse")]
public readonly record struct HostsGetFriendlyNameResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_FriendlyName")] string FriendlyName);
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct HostsGetInfoResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_FriendlynameMinChars")] ushort FriendlynameMinChar,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_FriendlynameMaxChars")] ushort FriendlynameMaxChars,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_HostnameMinChars")] ushort HostnameMinChars,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_HostnameMaxChars")] ushort HostnameMaxChars,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_HostnameAllowedChars")] string HostnameAllowedChars);
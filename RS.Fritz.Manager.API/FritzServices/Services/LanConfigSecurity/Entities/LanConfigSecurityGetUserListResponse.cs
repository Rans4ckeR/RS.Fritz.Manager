namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetUserListResponse")]
public readonly record struct LanConfigSecurityGetUserListResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UserList")] string UserList);
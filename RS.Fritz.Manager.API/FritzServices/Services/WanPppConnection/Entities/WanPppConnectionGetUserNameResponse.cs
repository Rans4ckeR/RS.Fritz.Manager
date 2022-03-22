namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetUserNameResponse")]
public readonly record struct WanPppConnectionGetUserNameResponse(
    [property: MessageBodyMember(Name = "NewUserName")] string UserName);
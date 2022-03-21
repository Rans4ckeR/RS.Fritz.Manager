namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetUserNameResponse")]
public readonly record struct WanPppConnectionGetUserNameResponse(
    [property: MessageBodyMember(Name = "NewUserName")] string UserName);
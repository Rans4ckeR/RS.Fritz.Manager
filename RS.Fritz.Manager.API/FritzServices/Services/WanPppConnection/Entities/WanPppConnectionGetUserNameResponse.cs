namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetUserNameResponse")]
public sealed record WanPppConnectionGetUserNameResponse
{
    [MessageBodyMember(Name = "NewUserName")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string UserName { get; set; }
}
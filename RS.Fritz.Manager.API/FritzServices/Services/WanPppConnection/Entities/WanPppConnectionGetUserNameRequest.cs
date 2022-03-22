namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetUserName")]
public readonly record struct WanPppConnectionGetUserNameRequest;
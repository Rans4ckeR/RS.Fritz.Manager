namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetUserName")]
public readonly record struct WanPppConnectionGetUserNameRequest;
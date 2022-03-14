namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetUserName")]
public sealed record WanPppConnectionGetUserNameRequest;
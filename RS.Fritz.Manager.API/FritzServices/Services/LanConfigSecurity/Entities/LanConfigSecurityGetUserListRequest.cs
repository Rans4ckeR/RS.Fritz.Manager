namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetUserList")]
public sealed record LanConfigSecurityGetUserListRequest;
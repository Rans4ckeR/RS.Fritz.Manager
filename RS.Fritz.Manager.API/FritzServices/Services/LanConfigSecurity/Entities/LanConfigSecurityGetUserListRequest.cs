namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetUserList")]
public readonly record struct LanConfigSecurityGetUserListRequest;
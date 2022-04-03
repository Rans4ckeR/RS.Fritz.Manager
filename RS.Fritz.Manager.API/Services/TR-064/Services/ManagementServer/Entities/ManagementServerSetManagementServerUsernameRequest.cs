namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetManagementServerUsername")]
public readonly record struct ManagementServerSetManagementServerUsernameRequest(
    [property: MessageBodyMember(Name = "NewUsername")] string Username);
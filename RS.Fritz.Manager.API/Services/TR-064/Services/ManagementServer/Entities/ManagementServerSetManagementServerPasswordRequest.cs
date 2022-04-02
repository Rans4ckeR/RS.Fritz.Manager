namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetManagementServerPassword")]
public readonly record struct ManagementServerSetManagementServerPasswordRequest(
    [property: MessageBodyMember(Name = "NewPassword")] string Password);
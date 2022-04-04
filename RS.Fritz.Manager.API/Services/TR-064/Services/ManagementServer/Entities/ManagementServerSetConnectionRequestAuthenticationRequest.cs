namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetConnectionRequestAuthentication")]
public readonly record struct ManagementServerSetConnectionRequestAuthenticationRequest(
    [property: MessageBodyMember(Name = "NewConnectionRequestUsername")] string ConnectionRequestUsername,
    [property: MessageBodyMember(Name = "NewConnectionRequestPassword")] string ConnectionRequestPassword);
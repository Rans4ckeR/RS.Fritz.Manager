namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetManagementServerUrl")]
public readonly record struct ManagementServerSetManagementServerUrlRequest(
    [property: MessageBodyMember(Name = "NewURL")] string Url);
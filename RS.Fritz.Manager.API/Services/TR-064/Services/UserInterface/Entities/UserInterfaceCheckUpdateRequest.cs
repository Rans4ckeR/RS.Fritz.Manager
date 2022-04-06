namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "CheckUpdate")]
public readonly record struct UserInterfaceCheckUpdateRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_LaborVersion")] string LaborVersion);
namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "DoUpdateResponse")]
public readonly record struct UserInterfaceDoUpdateResponse(
    [property: MessageBodyMember(Name = "NewUpgradeAvailable")] bool UpgradeAvailable,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UpdateState")] string UpdateState);
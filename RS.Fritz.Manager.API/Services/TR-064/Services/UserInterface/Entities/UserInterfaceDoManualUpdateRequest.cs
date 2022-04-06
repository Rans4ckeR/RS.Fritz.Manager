namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "DoManualUpdate")]
public readonly record struct UserInterfaceDoManualUpdateRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_DownloadURL")] string DownloadUrl,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AllowDowngrade")] bool AllowDowngrade);
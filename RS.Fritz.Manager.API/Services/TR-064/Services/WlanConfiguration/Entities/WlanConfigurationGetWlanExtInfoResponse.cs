namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetWlanExtInfoResponse")]
public readonly record struct WlanConfigurationGetWlanExtInfoResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_APEnabled")] string ApEnabled,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_APType")] string ApType,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_TimeoutActive")] string TimeoutActive,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Timeout")] string Timeout,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_TimeRemain")] string TimeRemain,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_NoForcedOff")] string NoForcedOff,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_UserIsolation")] string UserIsolation,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_EncryptionMode")] string EncryptionMode,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_LastChangedStamp")] uint LastChangedStamp);
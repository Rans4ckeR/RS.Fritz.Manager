namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetSupportDataInfoResponse")]
public readonly record struct DeviceConfigGetSupportDataInfoResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_SupportDataMode")] string SupportDataMode,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_SupportDataID")] string SupportDataId,
    [property: MessageBodyMember(Name = "NewX_AVMDE_SupportDataTimestamp")] DateTime SupportDataTimestamp,
    [property: MessageBodyMember(Name = "NewX_AVM-DE_SupportDataStatus")] string SupportDataStatus);
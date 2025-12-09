namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoGponResponse")]
public readonly record struct WanFiberGetInfoGponResponse(
    [property: MessageBodyMember(Name = "NewGponSerial")] string GponSerial,
    [property: MessageBodyMember(Name = "NewPONId")] string PonId,
    [property: MessageBodyMember(Name = "NewONUId")] uint OnuId,
    [property: MessageBodyMember(Name = "NewUNIType")] string UniType,
    [property: MessageBodyMember(Name = "NewGEMPortCount")] int GemPortCount);
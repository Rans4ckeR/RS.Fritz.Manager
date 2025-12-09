namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct WanDslInterfaceConfigGetInfoResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewStatus")] string Status,
    [property: MessageBodyMember(Name = "NewDataPath")] string DataPath,
    [property: MessageBodyMember(Name = "NewUpstreamCurrRate")] int UpstreamCurrRate, // spec: uint?
    [property: MessageBodyMember(Name = "NewDownstreamCurrRate")] int DownstreamCurrRate, // spec: uint
    [property: MessageBodyMember(Name = "NewUpstreamMaxRate")] int UpstreamMaxRate, // spec: uint
    [property: MessageBodyMember(Name = "NewDownstreamMaxRate")] int DownstreamMaxRate, // spec: uint
    [property: MessageBodyMember(Name = "NewUpstreamNoiseMargin")] int UpstreamNoiseMargin, // spec: uint
    [property: MessageBodyMember(Name = "NewDownstreamNoiseMargin")] int DownstreamNoiseMargin, // spec: uint
    [property: MessageBodyMember(Name = "NewUpstreamAttenuation")] int UpstreamAttenuation, // spec: uint
    [property: MessageBodyMember(Name = "NewDownstreamAttenuation")] int DownstreamAttenuation, // spec: uint
    [property: MessageBodyMember(Name = "NewATURVendor")] string AturVendor,
    [property: MessageBodyMember(Name = "NewATURCountry")] string AturCountry,
    [property: MessageBodyMember(Name = "NewUpstreamPower")] ushort UpstreamPower,
    [property: MessageBodyMember(Name = "NewDownstreamPower")] ushort DownstreamPower);
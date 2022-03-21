namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct WanDslInterfaceConfigGetInfoResponse(
    [property: MessageBodyMember(Name = "NewEnable")] bool Enable,
    [property: MessageBodyMember(Name = "NewStatus")] string Status,
    [property: MessageBodyMember(Name = "NewDataPath")] string DataPath,
    [property: MessageBodyMember(Name = "NewUpstreamCurrRate")] int UpstreamCurrRate,
    [property: MessageBodyMember(Name = "NewDownstreamCurrRate")] uint DownstreamCurrRate,
    [property: MessageBodyMember(Name = "NewUpstreamMaxRate")] uint UpstreamMaxRate,
    [property: MessageBodyMember(Name = "NewDownstreamMaxRate")] uint DownstreamMaxRate,
    [property: MessageBodyMember(Name = "NewUpstreamNoiseMargin")] uint UpstreamNoiseMargin,
    [property: MessageBodyMember(Name = "NewDownstreamNoiseMargin")] uint DownstreamNoiseMargin,
    [property: MessageBodyMember(Name = "NewUpstreamAttenuation")] uint UpstreamAttenuation,
    [property: MessageBodyMember(Name = "NewDownstreamAttenuation")] uint DownstreamAttenuation,
    [property: MessageBodyMember(Name = "NewATURVendor")] string ATURVendor,
    [property: MessageBodyMember(Name = "NewATURCountry")] string ATURCountry,
    [property: MessageBodyMember(Name = "NewUpstreamPower")] ushort UpstreamPower,
    [property: MessageBodyMember(Name = "NewDownstreamPower")] ushort DownstreamPower);
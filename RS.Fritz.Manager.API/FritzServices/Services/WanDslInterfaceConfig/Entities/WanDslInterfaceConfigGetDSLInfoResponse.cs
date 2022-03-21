namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDslInfoResponse")]
public readonly record struct WanDslInterfaceConfigGetDslInfoResponse(
    [property: MessageBodyMember(Name = "NewSNRGds")] uint SNRGds,
    [property: MessageBodyMember(Name = "NewSNRGus")] uint SNRGus,
    [property: MessageBodyMember(Name = "NewSNRpsds")] string SNRpsds,
    [property: MessageBodyMember(Name = "NewSNRpsus")] string SNRpsus,
    [property: MessageBodyMember(Name = "NewSNRMTds")] uint SNRMTds,
    [property: MessageBodyMember(Name = "NewSNRMTus")] uint SNRMTus,
    [property: MessageBodyMember(Name = "NewLATNds")] string LATNds,
    [property: MessageBodyMember(Name = "NewLATNus")] string LATNus,
    [property: MessageBodyMember(Name = "NewFECErrors")] uint FECErrors,
    [property: MessageBodyMember(Name = "NewCRCErrors")] uint CRCErrors,
    [property: MessageBodyMember(Name = "NewLinkStatus")] string LinkStatus,
    [property: MessageBodyMember(Name = "NewModulationType")] string ModulationType,
    [property: MessageBodyMember(Name = "NewCurrentProfile")] string CurrentProfile,
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
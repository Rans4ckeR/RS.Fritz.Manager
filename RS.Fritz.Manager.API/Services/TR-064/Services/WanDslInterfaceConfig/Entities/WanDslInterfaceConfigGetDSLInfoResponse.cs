namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDslInfoResponse")]
public readonly record struct WanDslInterfaceConfigGetDslInfoResponse(
    [property: MessageBodyMember(Name = "NewSNRGds")] uint SnrGDs,
    [property: MessageBodyMember(Name = "NewSNRGus")] uint SnrGUs,
    [property: MessageBodyMember(Name = "NewSNRpsds")] string SnrPsDs,
    [property: MessageBodyMember(Name = "NewSNRpsus")] string SnrPsUs,
    [property: MessageBodyMember(Name = "NewSNRMTds")] uint SnrMtDs,
    [property: MessageBodyMember(Name = "NewSNRMTus")] uint SnrMtUs,
    [property: MessageBodyMember(Name = "NewLATNds")] string LAtnDs,
    [property: MessageBodyMember(Name = "NewLATNus")] string LAtnUs,
    [property: MessageBodyMember(Name = "NewFECErrors")] uint FecErrors,
    [property: MessageBodyMember(Name = "NewCRCErrors")] uint CrcErrors,
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
    [property: MessageBodyMember(Name = "NewATURVendor")] string AturVendor,
    [property: MessageBodyMember(Name = "NewATURCountry")] string AturCountry,
    [property: MessageBodyMember(Name = "NewUpstreamPower")] ushort UpstreamPower,
    [property: MessageBodyMember(Name = "NewDownstreamPower")] ushort DownstreamPower);
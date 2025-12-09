namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDslInfoResponse")]
public readonly record struct WanDslInterfaceConfigGetDslInfoResponse(
    [property: MessageBodyMember(Name = "NewSNRGds")] int SnrGDs, // spec: uint
    [property: MessageBodyMember(Name = "NewSNRGus")] int SnrGUs, // spec: uint
    [property: MessageBodyMember(Name = "NewSNRpsds")] string SnrPsDs,
    [property: MessageBodyMember(Name = "NewSNRpsus")] string SnrPsUs,
    [property: MessageBodyMember(Name = "NewSNRMTds")] int SnrMtDs, // spec: uint
    [property: MessageBodyMember(Name = "NewSNRMTus")] int SnrMtUs, // spec: uint
    [property: MessageBodyMember(Name = "NewLATNds")] string LAtnDs,
    [property: MessageBodyMember(Name = "NewLATNus")] string LAtnUs,
    [property: MessageBodyMember(Name = "NewFECErrors")] int FecErrors, // spec: uint
    [property: MessageBodyMember(Name = "NewCRCErrors")] int CrcErrors, // spec: uint
    [property: MessageBodyMember(Name = "NewLinkStatus")] string LinkStatus,
    [property: MessageBodyMember(Name = "NewModulationType")] string ModulationType,
    [property: MessageBodyMember(Name = "NewCurrentProfile")] string CurrentProfile,
    [property: MessageBodyMember(Name = "NewUpstreamCurrRate")] int UpstreamCurrRate,
    [property: MessageBodyMember(Name = "NewDownstreamCurrRate")] uint DownstreamCurrRate,
    [property: MessageBodyMember(Name = "NewUpstreamMaxRate")] int UpstreamMaxRate, // spec: uint
    [property: MessageBodyMember(Name = "NewDownstreamMaxRate")] int DownstreamMaxRate, // spec: uint
    [property: MessageBodyMember(Name = "NewUpstreamNoiseMargin")] int UpstreamNoiseMargin, // spec: uint
    [property: MessageBodyMember(Name = "NewDownstreamNoiseMargin")] int DownstreamNoiseMargin, // spec: uint
    [property: MessageBodyMember(Name = "NewUpstreamAttenuation")] int UpstreamAttenuation, // spec: uint
    [property: MessageBodyMember(Name = "NewDownstreamAttenuation")] int DownstreamAttenuation, // spec: uint
    [property: MessageBodyMember(Name = "NewATURVendor")] string AturVendor,
    [property: MessageBodyMember(Name = "NewATURCountry")] string AturCountry,
    [property: MessageBodyMember(Name = "NewUpstreamPower")] short UpstreamPower, // spec: ushort
    [property: MessageBodyMember(Name = "NewDownstreamPower")] short DownstreamPower); // spec: ushort
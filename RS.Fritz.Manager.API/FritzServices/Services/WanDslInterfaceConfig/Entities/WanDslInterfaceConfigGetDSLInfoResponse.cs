namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetDSLInfoResponse")]
#pragma warning disable S101 // Types should be named in PascalCase
    public sealed record WanDslInterfaceConfigGetDSLInfoResponse
#pragma warning restore S101 // Types should be named in PascalCase
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [MessageBodyMember(Name = "NewSNRGds")]
        public uint SNRGds { get; set; }

        [MessageBodyMember(Name = "NewSNRGus")]
        public uint SNRGus { get; set; }

        [MessageBodyMember(Name = "NewSNRpsds")]
        public string SNRpsds { get; set; }

        [MessageBodyMember(Name = "NewSNRpsus")]
        public string SNRpsus { get; set; }

        [MessageBodyMember(Name = "NewSNRMTds")]
        public uint SNRMTds { get; set; }

        [MessageBodyMember(Name = "NewSNRMTus")]
        public uint SNRMTus { get; set; }

        [MessageBodyMember(Name = "NewLATNds")]
        public string LATNds { get; set; }

        [MessageBodyMember(Name = "NewLATNus")]
        public string LATNus { get; set; }

        [MessageBodyMember(Name = "NewFECErrors")]
        public uint FECErrors { get; set; }

        [MessageBodyMember(Name = "NewCRCErrors")]
        public uint CRCErrors { get; set; }

        [MessageBodyMember(Name = "NewLinkStatus")]
        public string LinkStatus { get; set; }

        [MessageBodyMember(Name = "NewModulationType")]
        public string ModulationType { get; set; }

        [MessageBodyMember(Name = "NewCurrentProfile")]
        public string CurrentProfile { get; set; }

        [MessageBodyMember(Name = "NewUpstreamCurrRate")]
        public int UpstreamCurrRate { get; set; }

        [MessageBodyMember(Name = "NewDownstreamCurrRate")]
        public uint DownstreamCurrRate { get; set; }

        [MessageBodyMember(Name = "NewUpstreamMaxRate")]
        public uint UpstreamMaxRate { get; set; }

        [MessageBodyMember(Name = "NewDownstreamMaxRate")]
        public uint DownstreamMaxRate { get; set; }

        [MessageBodyMember(Name = "NewUpstreamNoiseMargin")]
        public uint UpstreamNoiseMargin { get; set; }

        [MessageBodyMember(Name = "NewDownstreamNoiseMargin")]
        public uint DownstreamNoiseMargin { get; set; }

        [MessageBodyMember(Name = "NewUpstreamAttenuation")]
        public uint UpstreamAttenuation { get; set; }

        [MessageBodyMember(Name = "NewDownstreamAttenuation")]
        public uint DownstreamAttenuation { get; set; }

        [MessageBodyMember(Name = "NewATURVendor")]
        public string ATURVendor { get; set; }

        [MessageBodyMember(Name = "NewATURCountry")]
        public string ATURCountry { get; set; }

        [MessageBodyMember(Name = "NewUpstreamPower")]
        public ushort UpstreamPower { get; set; }

        [MessageBodyMember(Name = "NewDownstreamPower")]
        public ushort DownstreamPower { get; set; }
    }
}
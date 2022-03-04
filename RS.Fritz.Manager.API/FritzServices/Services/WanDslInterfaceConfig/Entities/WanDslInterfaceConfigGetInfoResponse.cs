namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetInfoResponse")]
    public sealed record WanDslInterfaceConfigGetInfoResponse
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [MessageBodyMember(Name = "NewEnable")]
        public bool Enable { get; set; }

        [MessageBodyMember(Name = "NewStatus")]
        public string Status { get; set; }

        [MessageBodyMember(Name = "NewDataPath")]
        public string DataPath { get; set; }

        [MessageBodyMember(Name = "NewUpstreamCurrRate")]
        public uint UpstreamCurrRate { get; set; }

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
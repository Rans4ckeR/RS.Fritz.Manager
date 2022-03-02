namespace RS.Fritz.Manager.Domain
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetCommonLinkPropertiesResponse")]

    public sealed record WanCommonInterfaceConfigGetCommonLinkPropertiesResponse
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        [MessageBodyMember(Name = "NewWANAccessType")]
        public string WanAccessType { get; set; }

        [MessageBodyMember(Name = "NewLayer1UpstreamMaxBitRate")]
        public uint Layer1UpstreamMaxBitRate { get; set; }

        [MessageBodyMember(Name = "NewLayer1DownstreamMaxBitRate")]
        public uint Layer1DownstreamMaxBitRate { get; set; }

        [MessageBodyMember(Name = "NewPhysicalLinkStatus")]
        public string PhysicalLinkStatus { get; set; }
    }
}
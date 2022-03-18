namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetInfoResponse")]
public sealed record WanDslLinkConfigGetInfoResponse
{
    [MessageBodyMember(Name = "NewEnable")]
    public bool Enable { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessageBodyMember(Name = "NewLinkStatus")]
    public string LinkStatus { get; set; }

    [MessageBodyMember(Name = "NewLinkType")]
    public string LinkType { get; set; }

    [MessageBodyMember(Name = "NewDestinationAddress")]
    public string DestinationAddress { get; set; }

    [MessageBodyMember(Name = "NewATMEncapsulation")]
    public string AtmEncapsulation { get; set; }

    [MessageBodyMember(Name = "NewAutoConfig")]
    public bool AutoConfig { get; set; }

    [MessageBodyMember(Name = "NewATMQoS")]
    public string AtmQos { get; set; }

    [MessageBodyMember(Name = "NewATMPeakCellRate")]
    public uint AtmPeakCellRate { get; set; }

    [MessageBodyMember(Name = "NewATMSustainableCellRate")]
    public uint AtmSustainableCellRate { get; set; }
}
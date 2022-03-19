namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetStatisticsResponse")]
public sealed record WanDslLinkConfigGetStatisticsResponse
{
    [MessageBodyMember(Name = "NewATMTransmittedBlocks")]
    public uint AtmTransmittedBlocks { get; set; }

    [MessageBodyMember(Name = "NewATMReceivedBlocks")]
    public uint AtmReceivedBlocks { get; set; }

    [MessageBodyMember(Name = "NewAAL5CRCErrors")]
    public uint Aal5CrcErrors { get; set; }

    [MessageBodyMember(Name = "NewATMCRCErrors")]
    public uint AtmCrcErrors { get; set; }
}
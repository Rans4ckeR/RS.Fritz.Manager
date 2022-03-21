namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetStatisticsResponse")]
public readonly record struct WanDslLinkConfigGetStatisticsResponse(
    [property: MessageBodyMember(Name = "NewATMTransmittedBlocks")] uint AtmTransmittedBlocks,
    [property: MessageBodyMember(Name = "NewATMReceivedBlocks")] uint AtmReceivedBlocks,
    [property: MessageBodyMember(Name = "NewAAL5CRCErrors")] uint Aal5CrcErrors,
    [property: MessageBodyMember(Name = "NewATMCRCErrors")] uint AtmCrcErrors);
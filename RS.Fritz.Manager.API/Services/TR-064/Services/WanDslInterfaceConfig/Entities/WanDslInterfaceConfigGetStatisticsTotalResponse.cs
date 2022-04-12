namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetStatisticsTotalResponse")]
public readonly record struct WanDslInterfaceConfigGetStatisticsTotalResponse(
    [property: MessageBodyMember(Name = "NewReceiveBlocks")] uint ReceiveBlocks,
    [property: MessageBodyMember(Name = "NewTransmitBlocks")] uint TransmitBlocks,
    [property: MessageBodyMember(Name = "NewCellDelin")] uint CellDelin,
    [property: MessageBodyMember(Name = "NewLinkRetrain")] uint LinkRetrain,
    [property: MessageBodyMember(Name = "NewInitErrors")] uint InitErrors,
    [property: MessageBodyMember(Name = "NewInitTimeouts")] uint InitTimeouts,
    [property: MessageBodyMember(Name = "NewLossOfFraming")] uint LossOfFraming,
    [property: MessageBodyMember(Name = "NewErroredSecs")] uint ErroredSecs,
    [property: MessageBodyMember(Name = "NewSeverelyErroredSecs")] uint SeverelyErroredSecs,
    [property: MessageBodyMember(Name = "NewFECErrors")] uint FecErrors,
    [property: MessageBodyMember(Name = "NewATUCFECErrors")] uint AtucFecErrors,
    [property: MessageBodyMember(Name = "NewHECErrors")] uint HecErrors,
    [property: MessageBodyMember(Name = "NewATUCHECErrors")] uint AtucHecErrors,
    [property: MessageBodyMember(Name = "NewATUCCRCErrors")] uint AtucCrcErrors,
    [property: MessageBodyMember(Name = "NewCRCErrors")] uint CrcErrors);
namespace RS.Fritz.Manager.API;

using System.ServiceModel;

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
    [property: MessageBodyMember(Name = "NewFECErrors")] uint FECErrors,
    [property: MessageBodyMember(Name = "NewATUCFECErrors")] uint ATUCFECErrors,
    [property: MessageBodyMember(Name = "NewHECErrors")] uint HECErrors,
    [property: MessageBodyMember(Name = "NewATUCHECErrors")] uint ATUCHECErrors,
    [property: MessageBodyMember(Name = "NewATUCCRCErrors")] uint ATUCCRCErrors,
    [property: MessageBodyMember(Name = "NewCRCErrors")] uint CRCErrors);
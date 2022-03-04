namespace RS.Fritz.Manager.API
{
    using System.ServiceModel;

    [MessageContract(WrapperName = "GetStatisticsTotalResponse")]
    public sealed record WanDslInterfaceConfigGetStatisticsTotalResponse
    {
        [MessageBodyMember(Name = "NewReceiveBlocks")]
        public uint ReceiveBlocks { get; set; }

        [MessageBodyMember(Name = "NewTransmitBlocks")]
        public uint TransmitBlocks { get; set; }

        [MessageBodyMember(Name = "NewCellDelin")]
        public uint CellDelin { get; set; }

        [MessageBodyMember(Name = "NewLinkRetrain")]
        public uint LinkRetrain { get; set; }

        [MessageBodyMember(Name = "NewInitErrors")]
        public uint InitErrors { get; set; }

        [MessageBodyMember(Name = "NewInitTimeouts")]
        public uint InitTimeouts { get; set; }

        [MessageBodyMember(Name = "NewLossOfFraming")]
        public uint LossOfFraming { get; set; }

        [MessageBodyMember(Name = "NewErroredSecs")]
        public uint ErroredSecs { get; set; }

        [MessageBodyMember(Name = "NewSeverelyErroredSecs")]
        public uint SeverelyErroredSecs { get; set; }

        [MessageBodyMember(Name = "NewFECErrors")]
        public uint FECErrors { get; set; }

        [MessageBodyMember(Name = "NewATUCFECErrors")]
        public uint ATUCFECErrors { get; set; }

        [MessageBodyMember(Name = "NewHECErrors")]
        public uint HECErrors { get; set; }

        [MessageBodyMember(Name = "NewATUCHECErrors")]
        public uint ATUCHECErrors { get; set; }

        [MessageBodyMember(Name = "NewATUCCRCErrors")]
        public uint ATUCCRCErrors { get; set; }

        [MessageBodyMember(Name = "NewCRCErrors")]
        public uint CRCErrors { get; set; }
    }
}
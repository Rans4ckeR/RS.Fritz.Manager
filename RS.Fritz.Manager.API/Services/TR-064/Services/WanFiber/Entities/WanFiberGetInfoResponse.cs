namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfoResponse")]
public readonly record struct WanFiberGetInfoResponse(
    [property: MessageBodyMember(Name = "NewOpticalSignalLevel")] int OpticalSignalLevel,
    [property: MessageBodyMember(Name = "NewLowerOpticalThreshold")] int LowerOpticalThreshold,
    [property: MessageBodyMember(Name = "NewUpperOpticalThreshold")] int UpperOpticalThreshold,
    [property: MessageBodyMember(Name = "NewTransmitOpticalLevel")] int TransmitOpticalLevel,
    [property: MessageBodyMember(Name = "NewLowerTransmitPowerThreshold")] int LowerTransmitPowerThreshold,
    [property: MessageBodyMember(Name = "NewUpperTransmitPowerThreshold")] int UpperTransmitPowerThreshold,
    [property: MessageBodyMember(Name = "NewSFPVendor")] string SfpVendor,
    [property: MessageBodyMember(Name = "NewSFPPartNumber")] string SfpPartNumber,
    [property: MessageBodyMember(Name = "NewSFPSerialNumber")] string SfpSerialNumber,
    [property: MessageBodyMember(Name = "NewSFPType")] int SfpType,
    [property: MessageBodyMember(Name = "NewTXWaveLength")] uint TxWaveLength,
    [property: MessageBodyMember(Name = "NewFiberMode")] string FiberMode);
namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WLANConfiguration:3")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWlanConfiguration3Service
{
    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:3#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest);
}
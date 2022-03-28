namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WLANConfiguration:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWlanConfiguration1Service
{
    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#X_AVM-DE_GetWLANDeviceListPath")]
    [FaultContract(typeof(UPnPFault))]
    public Task<WlanConfigurationGetWlanDeviceListPathResponse> GetWlanDeviceListPathAsync(WlanConfigurationGetWlanDeviceListPathRequest wlanConfigurationGetWlanDeviceListPathRequest);
}
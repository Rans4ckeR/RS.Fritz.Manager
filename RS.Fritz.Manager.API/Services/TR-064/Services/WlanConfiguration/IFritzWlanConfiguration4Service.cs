namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WLANConfiguration:4")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWlanConfiguration4Service
{
    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetInfo")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest);
}
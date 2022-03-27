namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:X_AVM-DE_Speedtest:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzAvmSpeedtestService
{
    [OperationContract(Action = "urn:dslforum-org:service:X_AVM-DE_Speedtest:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    public Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest);
}
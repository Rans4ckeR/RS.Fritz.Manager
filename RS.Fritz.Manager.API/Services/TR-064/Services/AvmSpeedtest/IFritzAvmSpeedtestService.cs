namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:X_AVM-DE_Speedtest:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzAvmSpeedtestService : IAsyncDisposable
{
    [OperationContract(Action = "urn:dslforum-org:service:X_AVM-DE_Speedtest:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:X_AVM-DE_Speedtest:1#GetStatistics")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<AvmSpeedtestGetStatisticsResponse> GetStatisticsAsync(AvmSpeedtestGetStatisticsRequest avmSpeedtestGetStatisticsRequest);
}
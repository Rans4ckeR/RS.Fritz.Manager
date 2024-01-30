namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:X_AVM-DE_Speedtest:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzAvmSpeedtestService : IAsyncDisposable
{
    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:X_AVM-DE_Speedtest:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:X_AVM-DE_Speedtest:1#GetStatistics")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<AvmSpeedtestGetStatisticsResponse> GetStatisticsAsync(AvmSpeedtestGetStatisticsRequest avmSpeedtestGetStatisticsRequest);
}
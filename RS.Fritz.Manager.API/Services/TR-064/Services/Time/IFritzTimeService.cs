namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:Time:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzTimeService : IAsyncDisposable
{
    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Time:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<TimeGetInfoResponse> GetInfoAsync(TimeGetInfoRequest timeGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:Time:1#SetNTPServers")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<TimeSetNtpServersResponse> SetNtpServersAsync(TimeSetNtpServersRequest timeSetNtpServersRequest);
}
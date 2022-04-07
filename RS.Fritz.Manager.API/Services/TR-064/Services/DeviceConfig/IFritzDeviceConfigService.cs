namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:DeviceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzDeviceConfigService
{
    [OperationContract(Action = "urn:dslforum-org:service:DeviceConfig:1#GetPersistentData")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<DeviceConfigGetPersistentDataResponse> GetPersistentDataAsync(DeviceConfigGetPersistentDataRequest deviceConfigGetPersistentDataRequest);
}
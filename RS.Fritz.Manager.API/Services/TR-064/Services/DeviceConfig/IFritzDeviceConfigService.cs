namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:DeviceConfig:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzDeviceConfigService : IAsyncDisposable
{
    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:DeviceConfig:1#GetPersistentData")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<DeviceConfigGetPersistentDataResponse> GetPersistentDataAsync(DeviceConfigGetPersistentDataRequest deviceConfigGetPersistentDataRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:DeviceConfig:1#X_GenerateUUID")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<DeviceConfigGenerateUuIdResponse> GenerateUuIdAsync(DeviceConfigGenerateUuIdRequest deviceConfigGenerateUuIdRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:DeviceConfig:1#X_AVM-DE_CreateUrlSID")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<DeviceConfigCreateUrlSidResponse> CreateUrlSidAsync(DeviceConfigCreateUrlSidRequest deviceConfigCreateUrlSidRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:DeviceConfig:1#X_AVM-DE_GetSupportDataInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<DeviceConfigGetSupportDataInfoResponse> GetSupportDataInfoAsync(DeviceConfigGetSupportDataInfoRequest deviceConfigGetSupportDataInfoRequest);
}
namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzUserInterfaceService : IAsyncDisposable
{
    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<UserInterfaceGetInfoResponse> GetInfoAsync(UserInterfaceGetInfoRequest userInterfaceGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1#X_AVM-DE_CheckUpdate")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<UserInterfaceCheckUpdateResponse> CheckUpdateAsync(UserInterfaceCheckUpdateRequest userInterfaceCheckUpdateRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1#X_AVM-DE_DoPrepareCGI")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<UserInterfaceDoPrepareCgiResponse> DoPrepareCgiAsync(UserInterfaceDoPrepareCgiRequest userInterfaceDoPrepareCgiRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1#X_AVM-DE_DoUpdate")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<UserInterfaceDoUpdateResponse> DoUpdateAsync(UserInterfaceDoUpdateRequest userInterfaceDoUpdateRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1#X_AVM-DE_DoManualUpdate")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<UserInterfaceDoManualUpdateResponse> DoManualUpdateAsync(UserInterfaceDoManualUpdateRequest userInterfaceDoManualUpdateRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1#X_AVM-DE_GetInternationalConfig")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<UserInterfaceGetInternationalConfigResponse> GetInternationalConfigAsync(UserInterfaceGetInternationalConfigRequest userInterfaceGetInternationalConfigRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1#X_AVM-DE_SetInternationalConfig")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<UserInterfaceSetInternationalConfigResponse> SetInternationalConfigAsync(UserInterfaceSetInternationalConfigRequest userInterfaceSetInternationalConfigRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1#X_AVM-DE_GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<UserInterfaceAvmGetInfoResponse> AvmGetInfoAsync(UserInterfaceAvmGetInfoRequest userInterfaceAvmGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:UserInterface:1#X_AVM-DE_SetConfig")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<UserInterfaceSetConfigResponse> SetConfigAsync(UserInterfaceSetConfigRequest userInterfaceSetConfigRequest);
}
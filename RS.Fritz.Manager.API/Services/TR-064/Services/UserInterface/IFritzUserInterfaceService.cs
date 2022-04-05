namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:UserInterface:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzUserInterfaceService
{
    [OperationContract(Action = "urn:dslforum-org:service:UserInterface:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<UserInterfaceGetInfoResponse> GetInfoAsync(UserInterfaceGetInfoRequest userInterfaceGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:UserInterface:1#X_AVM-DE_DoPrepareCGI")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<UserInterfaceDoPrepareCgiResponse> DoPrepareCgiAsync(UserInterfaceDoPrepareCgiRequest userInterfaceDoPrepareCgiRequest);

    [OperationContract(Action = "urn:dslforum-org:service:UserInterface:1#X_AVM-DE_DoUpdate")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<UserInterfaceDoUpdateResponse> DoUpdateAsync(UserInterfaceDoUpdateRequest userInterfaceDoUpdateRequest);
}
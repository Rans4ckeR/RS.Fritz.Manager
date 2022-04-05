namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:ManagementServer:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzManagementServerService
{
    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerGetInfoResponse> GetInfoAsync(ManagementServerGetInfoRequest managementServerGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#X_AVM-DE_GetTR069FirmwareDownloadEnabled")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerGetTr069FirmwareDownloadEnabledResponse> GetTr069FirmwareDownloadEnabledAsync(ManagementServerGetTr069FirmwareDownloadEnabledRequest managementServerGetTr069FirmwareDownloadEnabledRequest);

    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#SetManagementServerURL")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerSetManagementServerUrlResponse> SetManagementServerUrlAsync(ManagementServerSetManagementServerUrlRequest managementServerSetManagementServerUrlRequest);

    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#SetManagementServerUsername")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerSetManagementServerUsernameResponse> SetManagementServerUsernameAsync(ManagementServerSetManagementServerUsernameRequest managementServerSetManagementServerUsernameRequest);

    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#SetManagementServerPassword")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerSetManagementServerPasswordResponse> SetManagementServerPasswordAsync(ManagementServerSetManagementServerPasswordRequest managementServerSetManagementServerPasswordRequest);

    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#SetPeriodicInform")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerSetPeriodicInformResponse> SetPeriodicInformAsync(ManagementServerSetPeriodicInformRequest managementServerSetPeriodicInformRequest);

    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#SetConnectionRequestAuthentication")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerSetConnectionRequestAuthenticationResponse> SetConnectionRequestAuthenticationAsync(ManagementServerSetConnectionRequestAuthenticationRequest managementServerSetConnectionRequestAuthenticationRequest);

    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#SetUpgradeManagement")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerSetUpgradeManagementResponse> SetUpgradeManagementAsync(ManagementServerSetUpgradeManagementRequest managementServerSetUpgradeManagementRequest);

    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#X_SetTR069Enable")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerSetTr069EnableResponse> SetTr069EnableAsync(ManagementServerSetTr069EnableRequest managementServerSetTr069EnableRequest);

    [OperationContract(Action = "urn:dslforum-org:service:ManagementServer:1#X_AVM-DE_SetTR069FirmwareDownloadEnabled")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<ManagementServerSetTr069FirmwareDownloadEnabledResponse> SetTr069FirmwareDownloadEnabledAsync(ManagementServerSetTr069FirmwareDownloadEnabledRequest managementServerSetTr069FirmwareDownloadEnabledRequest);
}
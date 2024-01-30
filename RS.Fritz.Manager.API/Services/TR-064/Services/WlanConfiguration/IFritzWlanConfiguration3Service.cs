namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWlanConfiguration3Service : IAsyncDisposable
{
    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#X_AVM-DE_GetWLANDeviceListPath")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetWlanDeviceListPathResponse> GetWlanDeviceListPathAsync(WlanConfigurationGetWlanDeviceListPathRequest wlanConfigurationGetWlanDeviceListPathRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetBasBeaconSecurityProperties")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> GetBasBeaconSecurityPropertiesAsync(WlanConfigurationGetBasBeaconSecurityPropertiesRequest wlanConfigurationGetBasBeaconSecurityPropertiesRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetBSSID")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetBssIdResponse> GetBssIdAsync(WlanConfigurationGetBssIdRequest wlanConfigurationGetBssIdRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetSSID")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetSsIdResponse> GetSsIdAsync(WlanConfigurationGetSsIdRequest wlanConfigurationGetSsIdRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetBeaconType")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetBeaconTypeResponse> GetBeaconTypeAsync(WlanConfigurationGetBeaconTypeRequest wlanConfigurationGetBeaconTypeRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetChannelInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetChannelInfoResponse> GetChannelInfoAsync(WlanConfigurationGetChannelInfoRequest wlanConfigurationGetChannelInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetBeaconAdvertisement")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetBeaconAdvertisementResponse> GetBeaconAdvertisementAsync(WlanConfigurationGetBeaconAdvertisementRequest wlanConfigurationGetBeaconAdvertisementRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetTotalAssociations")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetTotalAssociationsResponse> GetTotalAssociationsAsync(WlanConfigurationGetTotalAssociationsRequest wlanConfigurationGetTotalAssociationsRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#X_AVM-DE_GetIPTVOptimized")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetIpTvOptimizedResponse> GetIpTvOptimizedAsync(WlanConfigurationGetIpTvOptimizedRequest wlanConfigurationGetIpTvOptimizedRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetStatistics")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetStatisticsResponse> GetStatisticsAsync(WlanConfigurationGetStatisticsRequest wlanConfigurationGetStatisticsRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#GetPacketStatistics")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetPacketStatisticsResponse> GetPacketStatisticsAsync(WlanConfigurationGetPacketStatisticsRequest wlanConfigurationGetPacketStatisticsRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#X_AVM-DE_GetNightControl")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetNightControlResponse> GetNightControlAsync(WlanConfigurationGetNightControlRequest wlanConfigurationGetNightControlRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#X_AVM-DE_GetWLANHybridMode")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetWlanHybridModeResponse> GetWlanHybridModeAsync(WlanConfigurationGetWlanHybridModeRequest wlanConfigurationGetWlanHybridModeRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#X_AVM-DE_GetWLANExtInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetWlanExtInfoResponse> GetWlanExtInfoAsync(WlanConfigurationGetWlanExtInfoRequest wlanConfigurationGetWlanExtInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#X_AVM-DE_GetWPSInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetWpsInfoResponse> GetWpsInfoAsync(WlanConfigurationGetWpsInfoRequest wlanConfigurationGetWpsInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:WLANConfiguration:3#X_AVM-DE_GetWLANConnectionInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<WlanConfigurationGetWlanConnectionInfoResponse> GetWlanConnectionInfoAsync(WlanConfigurationGetWlanConnectionInfoRequest wlanConfigurationGetWlanConnectionInfoRequest);
}
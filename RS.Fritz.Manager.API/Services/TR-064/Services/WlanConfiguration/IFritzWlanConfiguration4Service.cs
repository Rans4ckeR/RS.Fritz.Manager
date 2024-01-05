namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WLANConfiguration:4")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWlanConfiguration4Service : IAsyncDisposable
{
    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#X_AVM-DE_GetWLANDeviceListPath")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetWlanDeviceListPathResponse> GetWlanDeviceListPathAsync(WlanConfigurationGetWlanDeviceListPathRequest wlanConfigurationGetWlanDeviceListPathRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetBasBeaconSecurityProperties")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> GetBasBeaconSecurityPropertiesAsync(WlanConfigurationGetBasBeaconSecurityPropertiesRequest wlanConfigurationGetBasBeaconSecurityPropertiesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetBSSID")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetBssIdResponse> GetBssIdAsync(WlanConfigurationGetBssIdRequest wlanConfigurationGetBssIdRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetSSID")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetSsIdResponse> GetSsIdAsync(WlanConfigurationGetSsIdRequest wlanConfigurationGetSsIdRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetBeaconType")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetBeaconTypeResponse> GetBeaconTypeAsync(WlanConfigurationGetBeaconTypeRequest wlanConfigurationGetBeaconTypeRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetChannelInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetChannelInfoResponse> GetChannelInfoAsync(WlanConfigurationGetChannelInfoRequest wlanConfigurationGetChannelInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetBeaconAdvertisement")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetBeaconAdvertisementResponse> GetBeaconAdvertisementAsync(WlanConfigurationGetBeaconAdvertisementRequest wlanConfigurationGetBeaconAdvertisementRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetTotalAssociations")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetTotalAssociationsResponse> GetTotalAssociationsAsync(WlanConfigurationGetTotalAssociationsRequest wlanConfigurationGetTotalAssociationsRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#X_AVM-DE_GetIPTVOptimized")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetIpTvOptimizedResponse> GetIpTvOptimizedAsync(WlanConfigurationGetIpTvOptimizedRequest wlanConfigurationGetIpTvOptimizedRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetStatistics")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetStatisticsResponse> GetStatisticsAsync(WlanConfigurationGetStatisticsRequest wlanConfigurationGetStatisticsRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#GetPacketStatistics")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetPacketStatisticsResponse> GetPacketStatisticsAsync(WlanConfigurationGetPacketStatisticsRequest wlanConfigurationGetPacketStatisticsRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#X_AVM-DE_GetNightControl")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetNightControlResponse> GetNightControlAsync(WlanConfigurationGetNightControlRequest wlanConfigurationGetNightControlRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#X_AVM-DE_GetWLANHybridMode")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetWlanHybridModeResponse> GetWlanHybridModeAsync(WlanConfigurationGetWlanHybridModeRequest wlanConfigurationGetWlanHybridModeRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#X_AVM-DE_GetWLANExtInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetWlanExtInfoResponse> GetWlanExtInfoAsync(WlanConfigurationGetWlanExtInfoRequest wlanConfigurationGetWlanExtInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#X_AVM-DE_GetWPSInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetWpsInfoResponse> GetWpsInfoAsync(WlanConfigurationGetWpsInfoRequest wlanConfigurationGetWpsInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:4#X_AVM-DE_GetWLANConnectionInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    Task<WlanConfigurationGetWlanConnectionInfoResponse> GetWlanConnectionInfoAsync(WlanConfigurationGetWlanConnectionInfoRequest wlanConfigurationGetWlanConnectionInfoRequest);
}
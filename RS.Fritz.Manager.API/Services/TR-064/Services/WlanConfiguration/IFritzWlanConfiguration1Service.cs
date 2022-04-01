namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:WLANConfiguration:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzWlanConfiguration1Service
{
    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetInfoResponse> GetInfoAsync(WlanConfigurationGetInfoRequest wlanConfigurationGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#X_AVM-DE_GetWLANDeviceListPath")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetWlanDeviceListPathResponse> GetWlanDeviceListPathAsync(WlanConfigurationGetWlanDeviceListPathRequest wlanConfigurationGetWlanDeviceListPathRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetBasBeaconSecurityProperties")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetBasBeaconSecurityPropertiesResponse> GetBasBeaconSecurityPropertiesAsync(WlanConfigurationGetBasBeaconSecurityPropertiesRequest wlanConfigurationGetBasBeaconSecurityPropertiesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetBSSID")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetBssIdResponse> GetBssIdAsync(WlanConfigurationGetBssIdRequest wlanConfigurationGetBssIdRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetSSID")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetSsIdResponse> GetSsIdAsync(WlanConfigurationGetSsIdRequest wlanConfigurationGetSsIdRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetBeaconType")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetBeaconTypeResponse> GetBeaconTypeAsync(WlanConfigurationGetBeaconTypeRequest wlanConfigurationGetBeaconTypeRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetChannelInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetChannelInfoResponse> GetChannelInfoAsync(WlanConfigurationGetChannelInfoRequest wlanConfigurationGetChannelInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetBeaconAdvertisement")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetBeaconAdvertisementResponse> GetBeaconAdvertisementAsync(WlanConfigurationGetBeaconAdvertisementRequest wlanConfigurationGetBeaconAdvertisementRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetTotalAssociations")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetTotalAssociationsResponse> GetTotalAssociationsAsync(WlanConfigurationGetTotalAssociationsRequest wlanConfigurationGetTotalAssociationsRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#X_AVM-DE_GetIPTVOptimized")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetIpTvOptimizedResponse> GetIpTvOptimizedAsync(WlanConfigurationGetIpTvOptimizedRequest wlanConfigurationGetIpTvOptimizedRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetStatistics")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetStatisticsResponse> GetStatisticsAsync(WlanConfigurationGetStatisticsRequest wlanConfigurationGetStatisticsRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#GetPacketStatistics")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetPacketStatisticsResponse> GetPacketStatisticsAsync(WlanConfigurationGetPacketStatisticsRequest wlanConfigurationGetPacketStatisticsRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#X_AVM-DE_GetNightControl")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetNightControlResponse> GetNightControlAsync(WlanConfigurationGetNightControlRequest wlanConfigurationGetNightControlRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#X_AVM-DE_GetWLANHybridMode")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetWlanHybridModeResponse> GetWlanHybridModeAsync(WlanConfigurationGetWlanHybridModeRequest wlanConfigurationGetWlanHybridModeRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#X_AVM-DE_GetWLANExtInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetWlanExtInfoResponse> GetWlanExtInfoAsync(WlanConfigurationGetWlanExtInfoRequest wlanConfigurationGetWlanExtInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#X_AVM-DE_GetWPSInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetWpsInfoResponse> GetWpsInfoAsync(WlanConfigurationGetWpsInfoRequest wlanConfigurationGetWpsInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:WLANConfiguration:1#X_AVM-DE_GetWLANConnectionInfo")]
    [FaultContract(typeof(UPnPFault1))]
    [FaultContract(typeof(UPnPFault2))]
    public Task<WlanConfigurationGetWlanConnectionInfoResponse> GetWlanConnectionInfoAsync(WlanConfigurationGetWlanConnectionInfoRequest wlanConfigurationGetWlanConnectionInfoRequest);
}
namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = $"{UPnPConstants.AvmServiceNamespace}:LANHostConfigManagement:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLanHostConfigManagementService : IAsyncDisposable
{
    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANHostConfigManagement:1#GetInfo")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanHostConfigManagementGetInfoResponse> GetInfoAsync(LanHostConfigManagementGetInfoRequest lanHostConfigManagementGetInfoRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANHostConfigManagement:1#GetSubnetMask")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanHostConfigManagementGetSubnetMaskResponse> GetSubnetMaskAsync(LanHostConfigManagementGetSubnetMaskRequest lanHostConfigManagementGetSubnetMaskRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANHostConfigManagement:1#GetIPRoutersList")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanHostConfigManagementGetIpRoutersListResponse> GetIpRoutersListAsync(LanHostConfigManagementGetIpRoutersListRequest lanHostConfigManagementGetIpRoutersListRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANHostConfigManagement:1#GetAddressRange")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanHostConfigManagementGetAddressRangeResponse> GetAddressRangeAsync(LanHostConfigManagementGetAddressRangeRequest lanHostConfigManagementGetAddressRangeRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANHostConfigManagement:1#GetIPInterfaceNumberOfEntries")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse> GetIpInterfaceNumberOfEntriesAsync(LanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest lanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest);

    [OperationContract(Action = $"{UPnPConstants.AvmServiceNamespace}:LANHostConfigManagement:1#GetDNSServers")]
    [FaultContract(typeof(UPnPFault))]
    [FaultContract(typeof(AvmUPnPFault))]
    Task<LanHostConfigManagementGetDnsServersResponse> GetDnsServersAsync(LanHostConfigManagementGetDnsServersRequest lanHostConfigManagementGetDnsServersRequest);
}
namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:LANHostConfigManagement:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLanHostConfigManagementService
{
    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetInfo")]
    public Task<LanHostConfigManagementGetInfoResponse> GetInfoAsync(LanHostConfigManagementGetInfoRequest lanHostConfigManagementGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetSubnetMask")]
    public Task<LanHostConfigManagementGetSubnetMaskResponse> GetSubnetMaskAsync(LanHostConfigManagementGetSubnetMaskRequest lanHostConfigManagementGetSubnetMaskRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetIPRoutersList")]
    public Task<LanHostConfigManagementGetIpRoutersListResponse> GetIpRoutersListAsync(LanHostConfigManagementGetIpRoutersListRequest lanHostConfigManagementGetIpRoutersListRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetAddressRange")]
    public Task<LanHostConfigManagementGetAddressRangeResponse> GetAddressRangeAsync(LanHostConfigManagementGetAddressRangeRequest lanHostConfigManagementGetAddressRangeRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetIPInterfaceNumberOfEntries")]
    public Task<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse> GetIpInterfaceNumberOfEntriesAsync(LanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest lanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetDNSServers")]
    public Task<LanHostConfigManagementGetDnsServersResponse> GetDnsServersAsync(LanHostConfigManagementGetDnsServersRequest lanHostConfigManagementGetDnsServersRequest);
}
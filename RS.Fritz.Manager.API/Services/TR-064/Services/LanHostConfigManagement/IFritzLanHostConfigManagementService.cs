﻿namespace RS.Fritz.Manager.API;

[ServiceContract(Namespace = "urn:dslforum-org:service:LANHostConfigManagement:1")]
[XmlSerializerFormat(Style = OperationFormatStyle.Rpc, Use = OperationFormatUse.Encoded)]
internal interface IFritzLanHostConfigManagementService
{
    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetInfo")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanHostConfigManagementGetInfoResponse> GetInfoAsync(LanHostConfigManagementGetInfoRequest lanHostConfigManagementGetInfoRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetSubnetMask")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanHostConfigManagementGetSubnetMaskResponse> GetSubnetMaskAsync(LanHostConfigManagementGetSubnetMaskRequest lanHostConfigManagementGetSubnetMaskRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetIPRoutersList")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanHostConfigManagementGetIpRoutersListResponse> GetIpRoutersListAsync(LanHostConfigManagementGetIpRoutersListRequest lanHostConfigManagementGetIpRoutersListRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetAddressRange")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanHostConfigManagementGetAddressRangeResponse> GetAddressRangeAsync(LanHostConfigManagementGetAddressRangeRequest lanHostConfigManagementGetAddressRangeRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetIPInterfaceNumberOfEntries")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse> GetIpInterfaceNumberOfEntriesAsync(LanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest lanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest);

    [OperationContract(Action = "urn:dslforum-org:service:LANHostConfigManagement:1#GetDNSServers")]
    [FaultContract(typeof(FritzFaultContract), Name = "UPnPError", Namespace = "urn:schemas-upnp-org:control-1-0")]
    [XmlSerializerFormat(SupportFaults = true)]
    public Task<LanHostConfigManagementGetDnsServersResponse> GetDnsServersAsync(LanHostConfigManagementGetDnsServersRequest lanHostConfigManagementGetDnsServersRequest);
}
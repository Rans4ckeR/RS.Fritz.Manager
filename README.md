# RS.Fritz.Manager
A Windows .NET app with WPF UI to read information from and manage FritzBox devices using pure WCF calls.

Download latest version:
* [.NET 6](https://github.com/Rans4ckeR/RS.Fritz.Manager/releases/download/v0.1.0-alpha.7/RS.Fritz.Manager-v0.1.0-alpha.7-net6.0-windows.zip)
* [.NET 7 Preview](https://github.com/Rans4ckeR/RS.Fritz.Manager/releases/download/v0.1.0-alpha.7/RS.Fritz.Manager-v0.1.0-alpha.7-net7.0-windows.zip)

![Untitled](https://user-images.githubusercontent.com/25006126/130702690-2dbbd2a7-34c3-488a-bfd8-6e29dea2add2.png)

## Usage Instructions
1. Click Discover Internet Gateway Devices
2. Select a device from the list
3. Select a device user
4. Enter the selected user's password
5. Use the Device Information tab to see device details

## Service implementation status

### WAN
* 🔶 urn:dslforum-org:service:WANIPConnection:1
  * ✅ GetInfo
  * ❌ GetConnectionTypeInfo
  * ❌ SetConnectionType
  * ❌ GetStatusInfo
  * ❌ GetNATRSIPStatus
  * ❌ SetConnectionTrigger
  * ❌ ForceTermination
  * ❌ RequestConnection
  * ❌ X_GetDNSServers
  * ❌ X_SetDNSServers
  * ❌ GetPortMappingNumberOfEntries
  * ❌ GetGenericPortMappingEntry
  * ❌ GetSpecificPortMappingEntry
  * ❌ AddPortMapping
  * ❌ DeletePortMapping
  * ❌ GetExternalIPAddress
  * ❌ SetRouteProtocolRx
  * ❌ SetIdleDisconnectTime
* ❌ urn:dslforum-org:service:WANPPPConnection:1
* 🔶 urn:dslforum-org:service:WANCommonInterfaceConfig:1
  * ✅ GetCommonLinkProperties
  * ✅ GetTotalBytesSent
  * ✅ GetTotalBytesReceived
  * ❌ GetTotalPacketsSent
  * ❌ GetTotalPacketsReceived
  * ❌ X_AVM-DE_SetWANAccessType
  * ❌ X_AVM-DE_GetOnlineMonitor
* ❌ urn:dslforum-org:service:WANEthernetLinkConfig:1
* ✅ urn:dslforum-org:service:WANDSLInterfaceConfig:1
  * ✅ GetInfo
  * ✅ GetStatisticsTotal
  * ✅ X_AVM-DE_GetDSLDiagnoseInfo
  * ✅ X_AVM-DE_GetDSLInfo
* ❌ urn:dslforum-org:service:WANDSLLinkConfig:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Speedtest:1
* ❌ urn:dslforum-org:service:X_AVM-DE_RemoteAccess:1
* ❌ urn:dslforum-org:service:X_AVM-DE_MyFritz:1
* ❌ urn:dslforum-org:service:X_AVM-DE_HostFilter:1
* 🔶 urn:dslforum-org:service:Layer3Forwarding:1
  * ❌ SetDefaultConnectionService
  * ✅ GetDefaultConnectionService
  * ❌ GetForwardNumberOfEntries
  * ❌ AddForwardingEntry
  * ❌ DeleteForwardingEntry
  * ❌ GetSpecificForwardingEntry
  * ❌ GetGenericForwardingEntry
  * ❌ SetForwardingEntryEnable

### Telephony
* ❌ urn:dslforum-org:service:X_AVM-DE_OnTel:1
* ❌ urn:dslforum-org:service:X_AVM-DE_TAM:1
* ❌ urn:dslforum-org:service:X_VoIP:1

### Home network
* 🔶 urn:dslforum-org:service:Hosts:1
  * ✅ GetHostNumberOfEntries
  * ❌ GetSpecificHostEntry
  * ✅ GetGenericHostEntry
  * ❌ X_AVM-DE_GetChangeCounter
  * ❌ X_AVM-DE_GetAutoWakeOnLANByMACAddress
  * ❌ X_AVM-DE_SetAutoWakeOnLANByMACAddress
  * ❌ X_AVM-DE_SetHostNameByMACAddress
  * ❌ X_AVM-DE_WakeOnLANByMACAddress
  * ❌ X_AVM-DE_GetSpecificHostEntryByIp
  * ❌ X_AVM-DE_HostsCheckUpdate
  * ❌ X_AVM-DE_HostDoUpdate
  * ✅ X_AVM-DE_GetHostListPath
  * ❌ X_AVM-DE_GetMeshListPath
* ❌ urn:dslforum-org:service:WLANConfiguration:1
* ❌ urn:dslforum-org:service:LANHostConfigManagement:1
* ❌ urn:dslforum-org:service:LANEthernetInterfaceConfig:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Dect:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Homeauto:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Homeplug:1

### Storage/NAS
* ❌ urn:dslforum-org:service:X_AVM-DE_Storage:1
* ❌ urn:dslforum-org:service:X_AVM-DE_UPnP:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Filelinks:1

### System
* ✅ urn:dslforum-org:service:DeviceInfo:1
  * ✅ GetInfo
  * ✅ SetProvisioningCode
  * ✅ GetDeviceLog
  * ✅ GetSecurityPort
* ❌ urn:dslforum-org:service:DeviceConfig:1
* ✅ urn:dslforum-org:service:LANConfigSecurity:1
  * ✅ GetInfo
  * ✅ X_AVM-DE_GetAnonymousLogin
  * ✅ X_AVM-DE_GetCurrentUser
  * ✅ SetConfigPassword
  * ✅ X_AVM-DE_GetUserList
* ❌ urn:dslforum-org:service:X_AVM-DE_AppSetup:1
* ❌ urn:dslforum-org:service:X_AVM-DE_Auth:1
* ❌ urn:dslforum-org:service:Time:1
* ❌ urn:dslforum-org:service:UserInterface:1
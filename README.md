# RS.Fritz.Manager
A Windows .NET app with WPF UI to read information from and manage FritzBox devices using pure WCF calls.

Work in progress, all testing was done with a FritzBox 7530.

Implemented services:
* urn:dslforum-org:service:DeviceInfo:1
* urn:dslforum-org:service:LANConfigSecurity:1
* urn:dslforum-org:service:WANDSLInterfaceConfig:1

Partially implemented services:
* urn:dslforum-org:service:Layer3Forwarding:1
* urn:dslforum-org:service:WANPPPConnection:1

![Untitled](https://user-images.githubusercontent.com/25006126/130702690-2dbbd2a7-34c3-488a-bfd8-6e29dea2add2.png)

## Usage Instructions
1. Click Discover Internet Gateway Devices
2. Select a device from the list
3. Select a device user
4. Enter the selected user's password
5. Use the Device Information tab to see device details

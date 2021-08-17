# RS.Fritz.Manager
A Windows .NET app with WPF UI to read information from and manage FritzBox devices using pure WCF calls.

Work in progress with a rudimentary user expierence.
All testing was done with a FritzBox 7530.

Currently implemented services:
* urn:dslforum-org:service:DeviceInfo:1
* urn:dslforum-org:service:LANConfigSecurity:1
* urn:dslforum-org:service:WANDSLInterfaceConfig:1

![Untitled](https://user-images.githubusercontent.com/25006126/129746246-77dbc461-afdb-4df3-991b-3a6367bb5a45.png)

## Usage Instructions
1. Click Discover Internet Gateway Devices
2. Select a device from the list
3. Select a device user
4. Enter the selected user's password
5. Use the Device Information tab to see device details

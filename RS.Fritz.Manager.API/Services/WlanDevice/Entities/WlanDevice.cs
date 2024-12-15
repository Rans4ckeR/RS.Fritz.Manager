using System.Xml.Serialization;

namespace RS.Fritz.Manager.API;

public readonly record struct WlanDevice(
    [property: XmlElement(ElementName = "AssociatedDeviceIndex")] ushort AssociatedDeviceIndex,
    [property: XmlElement(ElementName = "AssociatedDeviceMACAddress")] string AssociatedDeviceMacAddress,
    [property: XmlElement(ElementName = "AssociatedDeviceIPAddress")] string AssociatedDeviceIpAddress,
    [property: XmlElement(ElementName = "AssociatedDeviceAuthState")] bool AssociatedDeviceAuthState,
    [property: XmlElement(ElementName = "X_AVM-DE_Speed")] ushort Speed,
    [property: XmlElement(ElementName = "X_AVM-DE_SignalStrength")] ushort SignalStrength,
    [property: XmlElement(ElementName = "AssociatedDeviceChannel")] ushort AssociatedDeviceChannel,
    [property: XmlElement(ElementName = "AssociatedDeviceGuest")] bool AssociatedDeviceGuest);
using System.Xml.Serialization;

namespace RS.Fritz.Manager.API;

[XmlRoot(ElementName = "List")]
public readonly record struct WlanDeviceList(
    [property: XmlElement(ElementName = "TotalAssociations")] ushort TotalAssociations,
    [property: XmlElement(ElementName = "Item")] WlanDevice[] Items);
namespace RS.Fritz.Manager.API;

using System.Xml.Serialization;

[XmlRoot(ElementName = "List")]
public readonly record struct UserList(
    [property: XmlElement(ElementName = "Username")] User[] Users);
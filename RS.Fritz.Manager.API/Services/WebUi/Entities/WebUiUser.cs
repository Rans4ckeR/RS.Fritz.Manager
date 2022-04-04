namespace RS.Fritz.Manager.API;

using System.Xml.Serialization;

public readonly record struct WebUiUser(
    [property: XmlAttribute(AttributeName = "last")] bool LastUser,
    [property: XmlText] string Name);
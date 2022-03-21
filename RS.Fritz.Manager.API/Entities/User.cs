namespace RS.Fritz.Manager.API;

using System.Xml.Serialization;

public readonly record struct User(
    [property: XmlAttribute(AttributeName = "last_user")] bool LastUser,
    [property: XmlText] string Name);
namespace RS.Fritz.Manager.API;

using System.Xml.Serialization;

public sealed record User
{
    [XmlAttribute(AttributeName = "last_user")]
    public bool LastUser { get; set; }

    [XmlText]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
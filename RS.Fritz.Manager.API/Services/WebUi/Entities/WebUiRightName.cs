using System.Xml.Serialization;

namespace RS.Fritz.Manager.API;

public sealed record WebUiRightName : WebUiRight
{
    [XmlText]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string Name { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
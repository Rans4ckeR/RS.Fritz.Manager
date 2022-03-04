namespace RS.Fritz.Manager.API
{
    using System.Xml.Serialization;

    public sealed record SpecVersion
    {
        [XmlElement(ElementName = "major")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string Major { get; set; }

        [XmlElement(ElementName = "minor")]
        public string Minor { get; set; }
    }
}
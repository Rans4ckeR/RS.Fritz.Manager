namespace RS.Fritz.Manager.API
{
    using System.Xml.Serialization;

    public sealed record SystemVersion
    {
        [XmlElement(ElementName = "HW")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string HW { get; set; }

        [XmlElement(ElementName = "Major")]
        public string Major { get; set; }

        [XmlElement(ElementName = "Minor")]
        public string Minor { get; set; }

        [XmlElement(ElementName = "Patch")]
        public string Patch { get; set; }

        [XmlElement(ElementName = "Buildnumber")]
        public string Buildnumber { get; set; }

        [XmlElement(ElementName = "Display")]
        public string Display { get; set; }
    }
}
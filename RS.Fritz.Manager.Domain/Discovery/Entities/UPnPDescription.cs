namespace RS.Fritz.Manager.Domain
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "root", Namespace = "urn:dslforum-org:device-1-0")]
    public sealed record UPnPDescription
    {
        [XmlElement(ElementName = "specVersion")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public SpecVersion SpecVersion { get; set; }

        [XmlElement(ElementName = "systemVersion")]
        public SystemVersion SystemVersion { get; set; }

        [XmlElement(ElementName = "device")]
        public Device Device { get; set; }
    }
}
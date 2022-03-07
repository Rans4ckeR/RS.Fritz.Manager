namespace RS.Fritz.Manager.API
{
    using System.Xml.Serialization;

    public sealed record Device
    {
        [XmlElement(ElementName = "deviceType")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string DeviceType { get; set; }

        [XmlElement(ElementName = "friendlyName")]
        public string FriendlyName { get; set; }

        [XmlElement(ElementName = "manufacturer")]
        public string Manufacturer { get; set; }

        [XmlElement(ElementName = "manufacturerURL")]
        public string ManufacturerUrl { get; set; }

        [XmlElement(ElementName = "modelDescription")]
        public string ModelDescription { get; set; }

        [XmlElement(ElementName = "modelName")]
        public string ModelName { get; set; }

        [XmlElement(ElementName = "modelNumber")]
        public string ModelNumber { get; set; }

        [XmlElement(ElementName = "modelURL")]
        public string ModelUrl { get; set; }

        [XmlElement(ElementName = "UDN")]
        public string UniqueDeviceName { get; set; }

        [XmlElement(ElementName = "presentationURL")]
        public string PresentationUrl { get; set; }
    }
}
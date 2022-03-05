namespace RS.Fritz.Manager.API
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "List")]
    public sealed record DeviceHostsList
    {
        [XmlElement(ElementName = "Item")]

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DeviceHost[] DeviceHosts { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    }
}
namespace RS.Fritz.Manager.Domain
{
    using System.Xml.Serialization;

    public sealed record User
    {
        [XmlAttribute(AttributeName = "last_user")]
        public bool LastUser { get; set; }

        [XmlText]
        public string Name { get; set; }
    }
}
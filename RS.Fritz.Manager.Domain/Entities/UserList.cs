namespace RS.Fritz.Manager.Domain
{
    using System.Xml.Serialization;

    [XmlRoot(ElementName = "List")]
    public sealed record UserList
    {
        [XmlElement(ElementName = "Username")]
        public User[] Users { get; set; }
    }
}
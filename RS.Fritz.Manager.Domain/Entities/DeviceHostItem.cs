namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;


    [XmlRoot(ElementName = "Item")]
    public class DeviceHostItem
    {
        

        [XmlElement(ElementName = "Index")]
        public string Index { get; set; }

        [XmlElement(ElementName = "Active")]
        public bool Active { get; set; }

        [XmlElement(ElementName = "HostName")]
        public string HostName { get; set; }


        [XmlElement(ElementName = "IPAddress")]
        public string IPAddress { get; set; }

        [XmlElement(ElementName = "MACAddress")]
        public string MACAddress { get; set; }

        [XmlElement(ElementName = "X_AVM-DE_Port")]

        public string X_AVM_DE_Port { get; set; }

        [XmlElement(ElementName = "X_AVM-DE_Speed")]

        public string X_AVM_DE_Speed { get; set; }

        [XmlElement(ElementName = "X_AVM-DE_Guest")]

        public string X_AVM_DE_Guest { get; set; }

        [XmlElement(ElementName = "X_AVM-DE_VPN")]

        public string X_AVM_DE_VPN { get; set; }

        [XmlElement(ElementName = "X_AVM-DE_WANAccess")]

        public string X_AVM_DE_WANAccess { get; set; }

        [XmlElement(ElementName = "X_AVM-DE_Disallow")]

        public string X_AVM_DE_Disallow { get; set; }
    }
}
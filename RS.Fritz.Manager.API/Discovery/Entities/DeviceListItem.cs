namespace RS.Fritz.Manager.API
{
    using System.Runtime.Serialization;

    [DataContract(Name = "device", Namespace = "urn:dslforum-org:device-1-0")]
    public sealed record DeviceListItem
    {
        [DataMember(Name = "deviceType", Order = 0)]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public string DeviceType { get; set; }

        [DataMember(Name = "friendlyName", Order = 1)]
        public string FriendlyName { get; set; }

        [DataMember(Name = "manufacturer", Order = 2)]
        public string Manufacturer { get; set; }

        [DataMember(Name = "manufacturerURL", Order = 3)]
        public string ManufacturerUrl { get; set; }

        [DataMember(Name = "modelDescription", Order = 4)]
        public string ModelDescription { get; set; }

        [DataMember(Name = "modelName", Order = 5)]
        public string ModelName { get; set; }

        [DataMember(Name = "modelNumber", Order = 6)]
        public string ModelNumber { get; set; }

        [DataMember(Name = "modelURL", Order = 7)]
        public string ModelUrl { get; set; }

        [DataMember(Name = "UDN", Order = 8)]
        public string Udn { get; set; }

        [DataMember(Name = "UPC", Order = 9)]
        public string Upc { get; set; }

        [DataMember(Name = "serviceList", Order = 9)]
        public ServiceListItem[] ServiceList { get; set; }
    }
}
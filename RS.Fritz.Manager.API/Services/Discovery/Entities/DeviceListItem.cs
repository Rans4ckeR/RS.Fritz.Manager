namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;

[DataContract(Name = "device", Namespace = "urn:dslforum-org:device-1-0")]
public readonly record struct DeviceListItem(
    [property: DataMember(Name = "deviceType", Order = 0)] string DeviceType,
    [property: DataMember(Name = "friendlyName", Order = 1)] string FriendlyName,
    [property: DataMember(Name = "manufacturer", Order = 2)] string Manufacturer,
    [property: DataMember(Name = "manufacturerURL", Order = 3)] string ManufacturerUrl,
    [property: DataMember(Name = "modelDescription", Order = 4)] string ModelDescription,
    [property: DataMember(Name = "modelName", Order = 5)] string ModelName,
    [property: DataMember(Name = "modelNumber", Order = 6)] string ModelNumber,
    [property: DataMember(Name = "modelURL", Order = 7)] string ModelUrl,
    [property: DataMember(Name = "UDN", Order = 8)] string UniqueDeviceName,
    [property: DataMember(Name = "UPC", Order = 9)] string Upc,
    [property: DataMember(Name = "serviceList", Order = 10)] ServiceListItem[] ServiceList);
﻿using System.Runtime.Serialization;

namespace RS.Fritz.Manager.API;

[DataContract(Name = UPnPConstants.Device, Namespace = UPnPConstants.Device10Namespace)]
internal readonly record struct SoapDevice(
    [property: DataMember(Name = "deviceType", Order = 0)] string DeviceType,
    [property: DataMember(Name = "friendlyName", Order = 1)] string FriendlyName,
    [property: DataMember(Name = "manufacturer", Order = 2)] string Manufacturer,
    [property: DataMember(Name = "manufacturerURL", Order = 3)] string ManufacturerUrl,
    [property: DataMember(Name = "modelDescription", Order = 4)] string ModelDescription,
    [property: DataMember(Name = "modelName", Order = 5)] string ModelName,
    [property: DataMember(Name = "modelNumber", Order = 6)] string ModelNumber,
    [property: DataMember(Name = "modelURL", Order = 7)] string ModelUrl,
    [property: DataMember(Name = "UDN", Order = 8)] string UniqueDeviceName,
    [property: DataMember(Name = "UPC", Order = 9)] string? UniversalProductCode,
    [property: DataMember(Name = "serialNumber", Order = 10)] string? SerialNumber,
    [property: DataMember(Name = "iconList", Order = 11)] ICollection<SoapIconListItem>? IconList,
    [property: DataMember(Name = "serviceList", Order = 12)] ICollection<SoapServiceListItem>? ServiceList,
    [property: DataMember(Name = "deviceList", Order = 13)] ICollection<SoapDevice>? DeviceList,
    [property: DataMember(Name = "presentationURL", Order = 14)] string? PresentationUrl);
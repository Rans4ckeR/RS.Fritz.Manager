namespace RS.Fritz.Manager.API;

public readonly record struct Device(
    string DeviceType,
    string FriendlyName,
    string Manufacturer,
    string ManufacturerUrl,
    string ModelDescription,
    string ModelName,
    string ModelNumber,
    string ModelUrl,
    string UniqueDeviceName,
    string? UniversalProductCode,
    string? SerialNumber,
    string? OriginUniqueDeviceName,
    ICollection<IconListItem>? IconList,
    ICollection<ServiceListItem>? ServiceList,
    ICollection<Device>? DeviceList,
    string? PresentationUrl);
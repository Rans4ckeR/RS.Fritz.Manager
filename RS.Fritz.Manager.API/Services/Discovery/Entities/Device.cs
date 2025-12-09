#pragma warning disable CA1054 // URI-like parameters should not be strings
#pragma warning disable CA1056 // URI-like properties should not be strings
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
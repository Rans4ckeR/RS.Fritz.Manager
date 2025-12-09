#pragma warning disable CA1054 // URI-like parameters should not be strings
#pragma warning disable CA1056 // URI-like properties should not be strings
namespace RS.Fritz.Manager.API;

public readonly record struct UPnPDescription(SpecVersion? SpecVersion, string? UrlBase, Device? Device, SystemVersion? SystemVersion);
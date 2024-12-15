namespace RS.Fritz.Manager.API;

public readonly record struct UPnPDescription(SpecVersion? SpecVersion, string? UrlBase, Device? Device, SystemVersion? SystemVersion);
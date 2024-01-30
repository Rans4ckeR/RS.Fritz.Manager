namespace RS.Fritz.Manager.API;

public readonly record struct ServiceListItem(string ServiceType, string ServiceId, string ControlUrl, string EventSubUrl, string ScpdUrl);
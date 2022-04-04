namespace RS.Fritz.Manager.API;

public readonly record struct WlanDeviceInfo(string WlanDeviceListPath, Uri WlanDeviceListPathLink, WlanDeviceList WlanDeviceList);
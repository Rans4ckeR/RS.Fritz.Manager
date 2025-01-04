namespace RS.Fritz.Manager.API;

public static class DeviceExtensions
{
    public static IEnumerable<ServiceListItem> GetServices(this Device device)
    {
        IEnumerable<ServiceListItem> serviceListItems = device.ServiceList ?? [];

        foreach (Device deviceListItem in device.DeviceList ?? [])
        {
            serviceListItems = [.. serviceListItems, .. GetServices(deviceListItem)];
        }

        return serviceListItems;
    }
}
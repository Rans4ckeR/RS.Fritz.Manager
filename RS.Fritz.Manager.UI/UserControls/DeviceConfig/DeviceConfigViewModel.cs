namespace RS.Fritz.Manager.UI;

internal sealed class DeviceConfigViewModel : FritzServiceViewModel
{
    private KeyValuePair<DeviceConfigGetPersistentDataResponse?, UPnPFault?>? deviceConfigGetPersistentDataResponse;

    public DeviceConfigViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "DeviceConfig")
    {
    }

    public KeyValuePair<DeviceConfigGetPersistentDataResponse?, UPnPFault?>? DeviceConfigGetPersistentDataResponse
    {
        get => deviceConfigGetPersistentDataResponse;
        private set { _ = SetProperty(ref deviceConfigGetPersistentDataResponse, value); }
    }

    protected override Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(new[]
            {
                GetDeviceConfigGetPersistentDataAsync()
            });
    }

    private async Task GetDeviceConfigGetPersistentDataAsync()
    {
        DeviceConfigGetPersistentDataResponse = await ExecuteApiAsync(q => q.DeviceConfigGetPersistentDataAsync());
    }
}
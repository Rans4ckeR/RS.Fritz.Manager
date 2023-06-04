namespace RS.Fritz.Manager.UI;

internal sealed class DeviceConfigViewModel : FritzServiceViewModel
{
    private KeyValuePair<DeviceConfigGetPersistentDataResponse?, UPnPFault?>? deviceConfigGetPersistentDataResponse;
    private KeyValuePair<DeviceConfigGetSupportDataInfoResponse?, UPnPFault?>? deviceConfigGetSupportDataInfoResponse;

    public DeviceConfigViewModel(
        DeviceLoginInfo deviceLoginInfo,
        ILogger logger,
        DeviceConfigGenerateUuIdViewModel deviceConfigGenerateUuIdViewModel,
        DeviceConfigCreateUrlSidViewModel deviceConfigCreateUrlSidViewModel)
        : base(deviceLoginInfo, logger, "DeviceConfig")
    {
        DeviceConfigGenerateUuIdViewModel = deviceConfigGenerateUuIdViewModel;
        DeviceConfigCreateUrlSidViewModel = deviceConfigCreateUrlSidViewModel;
    }

    public KeyValuePair<DeviceConfigGetPersistentDataResponse?, UPnPFault?>? DeviceConfigGetPersistentDataResponse
    {
        get => deviceConfigGetPersistentDataResponse;
        private set => _ = SetProperty(ref deviceConfigGetPersistentDataResponse, value);
    }

    public KeyValuePair<DeviceConfigGetSupportDataInfoResponse?, UPnPFault?>? DeviceConfigGetSupportDataInfoResponse
    {
        get => deviceConfigGetSupportDataInfoResponse;
        private set => _ = SetProperty(ref deviceConfigGetSupportDataInfoResponse, value);
    }

    public DeviceConfigGenerateUuIdViewModel DeviceConfigGenerateUuIdViewModel { get; }

    public DeviceConfigCreateUrlSidViewModel DeviceConfigCreateUrlSidViewModel { get; }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(
            new[]
            {
                GetDeviceConfigGetPersistentDataAsync(),
                GetDeviceConfigGetSupportDataInfoResponseAsync()
            },
            true);
    }

    private async Task GetDeviceConfigGetPersistentDataAsync()
        => DeviceConfigGetPersistentDataResponse = await ExecuteApiAsync(q => q.DeviceConfigGetPersistentDataAsync()).ConfigureAwait(true);

    private async Task GetDeviceConfigGetSupportDataInfoResponseAsync()
        => DeviceConfigGetSupportDataInfoResponse = await ExecuteApiAsync(q => q.DeviceConfigGetSupportDataInfoAsync()).ConfigureAwait(true);
}
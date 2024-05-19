namespace RS.Fritz.Manager.UI;

internal sealed class DeviceConfigViewModel(
    DeviceLoginInfo deviceLoginInfo,
    ILogger logger,
    DeviceConfigGenerateUuIdViewModel deviceConfigGenerateUuIdViewModel,
    DeviceConfigCreateUrlSidViewModel deviceConfigCreateUrlSidViewModel,
    DeviceConfigGetConfigFileViewModel deviceConfigGetConfigFileViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "DeviceConfig")
{
    private KeyValuePair<DeviceConfigGetPersistentDataResponse?, UPnPFault?>? deviceConfigGetPersistentDataResponse;
    private KeyValuePair<DeviceConfigGetSupportDataInfoResponse?, UPnPFault?>? deviceConfigGetSupportDataInfoResponse;

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

    public DeviceConfigGenerateUuIdViewModel DeviceConfigGenerateUuIdViewModel { get; } = deviceConfigGenerateUuIdViewModel;

    public DeviceConfigCreateUrlSidViewModel DeviceConfigCreateUrlSidViewModel { get; } = deviceConfigCreateUrlSidViewModel;

    public DeviceConfigGetConfigFileViewModel DeviceConfigGetConfigFileViewModel { get; } = deviceConfigGetConfigFileViewModel;

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => API.TaskExtensions.WhenAllSafe([GetDeviceConfigGetPersistentDataAsync(), GetDeviceConfigGetSupportDataInfoResponseAsync()], true);

    private async Task GetDeviceConfigGetPersistentDataAsync()
        => DeviceConfigGetPersistentDataResponse = await ExecuteApiAsync(q => q.DeviceConfigGetPersistentDataAsync()).ConfigureAwait(true);

    private async Task GetDeviceConfigGetSupportDataInfoResponseAsync()
        => DeviceConfigGetSupportDataInfoResponse = await ExecuteApiAsync(q => q.DeviceConfigGetSupportDataInfoAsync()).ConfigureAwait(true);
}
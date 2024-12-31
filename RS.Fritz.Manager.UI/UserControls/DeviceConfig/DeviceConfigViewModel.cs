namespace RS.Fritz.Manager.UI;

internal sealed class DeviceConfigViewModel(
    DeviceLoginInfo deviceLoginInfo,
    ILogger<DeviceConfigViewModel> logger,
    DeviceConfigGenerateUuIdViewModel deviceConfigGenerateUuIdViewModel,
    DeviceConfigCreateUrlSidViewModel deviceConfigCreateUrlSidViewModel,
    DeviceConfigGetConfigFileViewModel deviceConfigGetConfigFileViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "DeviceConfig")
{
    public KeyValuePair<DeviceConfigGetPersistentDataResponse?, UPnPFault?>? DeviceConfigGetPersistentDataResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<DeviceConfigGetSupportDataInfoResponse?, UPnPFault?>? DeviceConfigGetSupportDataInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public DeviceConfigGenerateUuIdViewModel DeviceConfigGenerateUuIdViewModel { get; } = deviceConfigGenerateUuIdViewModel;

    public DeviceConfigCreateUrlSidViewModel DeviceConfigCreateUrlSidViewModel { get; } = deviceConfigCreateUrlSidViewModel;

    public DeviceConfigGetConfigFileViewModel DeviceConfigGetConfigFileViewModel { get; } = deviceConfigGetConfigFileViewModel;

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => API.TaskExtensions.WhenAllSafe([GetDeviceConfigGetPersistentDataAsync(), GetDeviceConfigGetSupportDataInfoResponseAsync()], true);

    private async Task GetDeviceConfigGetPersistentDataAsync()
        => DeviceConfigGetPersistentDataResponse = await ExecuteApiAsync(static q => q.DeviceConfigGetPersistentDataAsync()).ConfigureAwait(true);

    private async Task GetDeviceConfigGetSupportDataInfoResponseAsync()
        => DeviceConfigGetSupportDataInfoResponse = await ExecuteApiAsync(static q => q.DeviceConfigGetSupportDataInfoAsync()).ConfigureAwait(true);
}
namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceViewModel(
    DeviceLoginInfo deviceLoginInfo,
    UserInterfaceCheckUpdateViewModel userInterfaceCheckUpdateViewModel,
    UserInterfaceDoPrepareCgiViewModel userInterfaceDoPrepareCgiViewModel,
    UserInterfaceDoUpdateViewModel userInterfaceDoUpdateViewModel,
    UserInterfaceDoManualUpdateViewModel userInterfaceDoManualUpdateViewModel,
    UserInterfaceSetInternationalConfigViewModel userInterfaceSetInternationalConfigViewModel,
    UserInterfaceSetConfigViewModel userInterfaceSetConfigViewModel,
    ILogger<UserInterfaceViewModel> logger)
    : FritzServiceViewModel(deviceLoginInfo, logger, "UserInterface")
{
    public KeyValuePair<UserInterfaceGetInfoResponse?, UPnPFault?>? UserInterfaceGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<UserInterfaceGetInternationalConfigResponse?, UPnPFault?>? UserInterfaceGetInternationalConfigResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<UserInterfaceAvmGetInfoResponse?, UPnPFault?>? UserInterfaceAvmGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public UserInterfaceCheckUpdateViewModel UserInterfaceCheckUpdateViewModel { get; } = userInterfaceCheckUpdateViewModel;

    public UserInterfaceDoPrepareCgiViewModel UserInterfaceDoPrepareCgiViewModel { get; } = userInterfaceDoPrepareCgiViewModel;

    public UserInterfaceDoUpdateViewModel UserInterfaceDoUpdateViewModel { get; } = userInterfaceDoUpdateViewModel;

    public UserInterfaceDoManualUpdateViewModel UserInterfaceDoManualUpdateViewModel { get; } = userInterfaceDoManualUpdateViewModel;

    public UserInterfaceSetInternationalConfigViewModel UserInterfaceSetInternationalConfigViewModel { get; } = userInterfaceSetInternationalConfigViewModel;

    public UserInterfaceSetConfigViewModel UserInterfaceSetConfigViewModel { get; } = userInterfaceSetConfigViewModel;

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => Task.WhenAll(
                GetUserInterfaceGetInfoAsync(),
                GetUserInterfaceGetInternationalConfigAsync(),
                GetUserInterfaceAvmGetInfoAsync())
            .Evaluate(ConfigureAwaitOptions.ContinueOnCapturedContext);

    private async Task GetUserInterfaceGetInfoAsync()
        => UserInterfaceGetInfoResponse = await ExecuteApiAsync(static q => q.UserInterfaceGetInfoAsync()).ConfigureAwait(true);

    private async Task GetUserInterfaceGetInternationalConfigAsync()
        => UserInterfaceGetInternationalConfigResponse = await ExecuteApiAsync(static q => q.UserInterfaceGetInternationalConfigAsync()).ConfigureAwait(true);

    private async Task GetUserInterfaceAvmGetInfoAsync()
        => UserInterfaceAvmGetInfoResponse = await ExecuteApiAsync(static q => q.UserInterfaceAvmGetInfoAsync()).ConfigureAwait(true);
}
namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceViewModel : FritzServiceViewModel
{
    private KeyValuePair<UserInterfaceGetInfoResponse?, UPnPFault?>? userInterfaceGetInfoResponse;
    private KeyValuePair<UserInterfaceGetInternationalConfigResponse?, UPnPFault?>? userInterfaceGetInternationalConfigResponse;
    private KeyValuePair<UserInterfaceAvmGetInfoResponse?, UPnPFault?>? userInterfaceAvmGetInfoResponse;

    public UserInterfaceViewModel(
        DeviceLoginInfo deviceLoginInfo,
        UserInterfaceCheckUpdateViewModel userInterfaceCheckUpdateViewModel,
        UserInterfaceDoPrepareCgiViewModel userInterfaceDoPrepareCgiViewModel,
        UserInterfaceDoUpdateViewModel userInterfaceDoUpdateViewModel,
        UserInterfaceDoManualUpdateViewModel userInterfaceDoManualUpdateViewModel,
        UserInterfaceSetInternationalConfigViewModel userInterfaceSetInternationalConfigViewModel,
        UserInterfaceSetConfigViewModel userInterfaceSetConfigViewModel,
        ILogger logger)
        : base(deviceLoginInfo, logger, "UserInterface")
    {
        UserInterfaceCheckUpdateViewModel = userInterfaceCheckUpdateViewModel;
        UserInterfaceDoPrepareCgiViewModel = userInterfaceDoPrepareCgiViewModel;
        UserInterfaceDoUpdateViewModel = userInterfaceDoUpdateViewModel;
        UserInterfaceDoManualUpdateViewModel = userInterfaceDoManualUpdateViewModel;
        UserInterfaceSetInternationalConfigViewModel = userInterfaceSetInternationalConfigViewModel;
        UserInterfaceSetConfigViewModel = userInterfaceSetConfigViewModel;
    }

    public KeyValuePair<UserInterfaceGetInfoResponse?, UPnPFault?>? UserInterfaceGetInfoResponse
    {
        get => userInterfaceGetInfoResponse;
        private set { _ = SetProperty(ref userInterfaceGetInfoResponse, value); }
    }

    public KeyValuePair<UserInterfaceGetInternationalConfigResponse?, UPnPFault?>? UserInterfaceGetInternationalConfigResponse
    {
        get => userInterfaceGetInternationalConfigResponse;
        private set { _ = SetProperty(ref userInterfaceGetInternationalConfigResponse, value); }
    }

    public KeyValuePair<UserInterfaceAvmGetInfoResponse?, UPnPFault?>? UserInterfaceAvmGetInfoResponse
    {
        get => userInterfaceAvmGetInfoResponse;
        private set { _ = SetProperty(ref userInterfaceAvmGetInfoResponse, value); }
    }

    public UserInterfaceCheckUpdateViewModel UserInterfaceCheckUpdateViewModel { get; }

    public UserInterfaceDoPrepareCgiViewModel UserInterfaceDoPrepareCgiViewModel { get; }

    public UserInterfaceDoUpdateViewModel UserInterfaceDoUpdateViewModel { get; }

    public UserInterfaceDoManualUpdateViewModel UserInterfaceDoManualUpdateViewModel { get; }

    public UserInterfaceSetInternationalConfigViewModel UserInterfaceSetInternationalConfigViewModel { get; }

    public UserInterfaceSetConfigViewModel UserInterfaceSetConfigViewModel { get; }

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(new[]
            {
               GetUserInterfaceGetInfoAsync(),
               GetUserInterfaceGetInternationalConfigAsync(),
               GetUserInterfaceAvmGetInfoAsync()
            });
    }

    private async Task GetUserInterfaceGetInfoAsync()
    {
        UserInterfaceGetInfoResponse = await ExecuteApiAsync(q => q.UserInterfaceGetInfoAsync());
    }

    private async Task GetUserInterfaceGetInternationalConfigAsync()
    {
        UserInterfaceGetInternationalConfigResponse = await ExecuteApiAsync(q => q.UserInterfaceGetInternationalConfigAsync());
    }

    private async Task GetUserInterfaceAvmGetInfoAsync()
    {
        UserInterfaceAvmGetInfoResponse = await ExecuteApiAsync(q => q.UserInterfaceAvmGetInfoAsync());
    }
}
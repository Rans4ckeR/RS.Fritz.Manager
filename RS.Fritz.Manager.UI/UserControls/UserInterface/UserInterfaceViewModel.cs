﻿namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceViewModel : FritzServiceViewModel
{
    private KeyValuePair<UserInterfaceGetInfoResponse?, UPnPFault?>? userInterfaceGetInfoResponse;

    public UserInterfaceViewModel(
        DeviceLoginInfo deviceLoginInfo,
        UserInterfaceCheckUpdateViewModel userInterfaceCheckUpdateViewModel,
        UserInterfaceDoPrepareCgiViewModel userInterfaceDoPrepareCgiViewModel,
        UserInterfaceDoUpdateViewModel userInterfaceDoUpdateViewModel,
        ILogger logger)
        : base(deviceLoginInfo, logger, "UserInterface")
    {
        UserInterfaceCheckUpdateViewModel = userInterfaceCheckUpdateViewModel;
        UserInterfaceDoUpdateViewModel = userInterfaceDoUpdateViewModel;
        UserInterfaceDoPrepareCgiViewModel = userInterfaceDoPrepareCgiViewModel;
    }

    public KeyValuePair<UserInterfaceGetInfoResponse?, UPnPFault?>? UserInterfaceGetInfoResponse
    {
        get => userInterfaceGetInfoResponse;
        private set { _ = SetProperty(ref userInterfaceGetInfoResponse, value); }
    }

    public UserInterfaceCheckUpdateViewModel UserInterfaceCheckUpdateViewModel { get; }

    public UserInterfaceDoPrepareCgiViewModel UserInterfaceDoPrepareCgiViewModel { get; }

    public UserInterfaceDoUpdateViewModel UserInterfaceDoUpdateViewModel { get; }

    protected override Task DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
    {
        return API.TaskExtensions.WhenAllSafe(new[]
            {
               GetUserInterfaceGetInfoAsync()
            });
    }

    private async Task GetUserInterfaceGetInfoAsync()
    {
        UserInterfaceGetInfoResponse = await ExecuteApiAsync(q => q.UserInterfaceGetInfoAsync());
    }
}
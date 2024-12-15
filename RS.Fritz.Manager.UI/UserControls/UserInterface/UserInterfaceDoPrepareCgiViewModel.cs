namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceDoPrepareCgiViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceDoPrepareCgiRequest, UserInterfaceDoPrepareCgiResponse>(deviceLoginInfo, logger, "DoPrepareCgi", "Prepare Cgi", (d, _) => d.UserInterfaceDoPrepareCgiAsync());
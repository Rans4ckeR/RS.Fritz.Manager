namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceDoPrepareCgiViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceDoPrepareCgiRequest, UserInterfaceDoPrepareCgiResponse>(deviceLoginInfo, logger, "DoPrepareCgi", "Prepare Cgi", static (d, _) => d.UserInterfaceDoPrepareCgiAsync());
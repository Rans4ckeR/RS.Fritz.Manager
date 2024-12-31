namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceDoPrepareCgiViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<UserInterfaceDoPrepareCgiViewModel> logger)
    : ManualOperationViewModel<UserInterfaceDoPrepareCgiRequest, UserInterfaceDoPrepareCgiResponse>(deviceLoginInfo, logger, "DoPrepareCgi", "Prepare Cgi", static (d, _) => d.UserInterfaceDoPrepareCgiAsync());
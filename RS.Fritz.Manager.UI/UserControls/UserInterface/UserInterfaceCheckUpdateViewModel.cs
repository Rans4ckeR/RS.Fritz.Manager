namespace RS.Fritz.Manager.UI;

internal sealed class UserInterfaceCheckUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<UserInterfaceCheckUpdateRequest, UserInterfaceCheckUpdateResponse>(deviceLoginInfo, logger, "CheckUpdate", "Check Update", static (d, r) => d.UserInterfaceCheckUpdateAsync(r));